using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject obj;

    public AudioSource bulletFx;
    public AudioSource chargeFX;
    
    private CurrentMenu esc;

    private Transform _posCanvas;
    private List<GameObject> _bullets;
    private List<float> _timeBullets;
    
    private float _lastTimeShoot;
    private bool _shotable = true;
    
    [SerializeField] private float cooldownShoot = 0.5f;
    [SerializeField] private float bulletSpeed = 3;

    [SerializeField] private float durationBullet = 10;
    
    [SerializeField] private int damage = 10;
    [SerializeField] private float cooldownBulletSpell = 10f;
    [SerializeField] private float durationBulletSpell = 1f;
    [SerializeField] private int boostDamageBullet = 3;

    private float _timeDuration;
    private float _timeCooldown;
    private bool _damageBoosted = true;

    private Transform _objectToPlace;

    public bool GetDamageBoosted()
    {
        return _damageBoosted;
    }
    
    public float GetCooldownBulletSpell()
    {
        return cooldownBulletSpell;
    }

    public int GetBoostDamageBullet()
    {
        return boostDamageBullet;
    }
    
    public float GetLastTimeShoot()
    {
        return _lastTimeShoot;
    }

    public float GetCooldownShoot()
    {
        return cooldownShoot;
    }

    public bool GetShootable()
    {
        return _shotable;
    }

    void Start()
    {
        _lastTimeShoot = -2;
        _bullets = new List<GameObject>();
        _timeBullets = new List<float>();
        
        esc = GameObject.FindWithTag("Menu").GetComponent<CurrentMenu>();
    }

    float GetCooToAngle()
    {
        var pos = Input.mousePosition;
        pos -= new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        
        return (float) Math.Atan2(pos.y * 1.42f, pos.x) * 180 / (float) Math.PI;
    }

    void Update()
    {
        if ((_lastTimeShoot + cooldownShoot < Time.time) &&
            (!_shotable)) // CHECKS THE COOLDOWN FOR THE SHOOTING
        {
            _shotable = true;
        }
        
        if (CurrentMenu._inMenu) // IF IN MENU THEN DO NOTHING
        {
            return;
        }

        if (Input.GetMouseButton(0) && _shotable) // INSTANTIATE A NEW AMO ON CLICK - WITH INFO : Who shot? Since When?
        {
            var angle = GetCooToAngle();
            
            _posCanvas = GetComponentInParent<Transform>();
            
            var newOne = Instantiate(obj); // INSTANTIATE A NEW AMO
            newOne.SetActive(true);
            newOne.transform.localPosition = _posCanvas.position;

            if (!_damageBoosted)
            {
                newOne.transform.GetChild(0).localScale *= 2;
                newOne.GetComponent<BoxCollider>().size *= 2;
            }
            
            var rb = newOne.GetComponent<Rigidbody>();
            
            angle = (angle % 360 + 360) % 360;
            angle = (float) (angle / 180 * Math.PI);
            
            rb.velocity = new Vector3((float) Math.Cos(angle), 
                                        0 , 
                                        (float) Math.Sin(angle)) * bulletSpeed;

            var bulletCollision = newOne.GetComponent<Bullet_Collision>();
            bulletCollision.tmp = gameObject.GetComponentsInParent<Transform>()[1].gameObject; // PUTS THE MOVING FRAME AS THE SHOOTER OF THIS AMO
            bulletCollision.SetDamage(damage);

            _bullets.Add(newOne);
            _timeBullets.Add(Time.time);

            _shotable = false;
            _lastTimeShoot = Time.time;
            
            if (!_damageBoosted)
                chargeFX.Play();
            else
                bulletFx.Play();
        }

        if (_timeBullets.Count > 0 && (_timeBullets[0] + durationBullet < Time.time)) // IF BULLET IS THERE MORE THAN _durationBullet (secs)
        {
            _timeBullets.RemoveAt(0);
            _bullets.RemoveAt(0);
        }

        for (var i = 0; i < _bullets.Count; i++) // CHECK IF BULLET IS DESTROYED
        {
            if (!_bullets[i].activeSelf)
            {
                Destroy(_bullets[i].gameObject);
                
                _timeBullets.RemoveAt(i);
                _bullets.RemoveAt(i);
            }
        }
        
        if (_timeDuration < 0) // CHECKS IF DAMAGE BOOST IS TO DISABLE
        {
            if (!_damageBoosted)
            {
                damage /= boostDamageBullet;
                _damageBoosted = true;
            }
            
            _timeDuration = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && _timeCooldown <= 0) // SET UP THE DAMAGE BOOST
        {
            _damageBoosted = false;
            _timeDuration = durationBulletSpell;
            _timeCooldown = cooldownBulletSpell;
            damage *= boostDamageBullet;
        }

        _timeDuration -= Time.deltaTime;
        _timeCooldown -= Time.deltaTime;
    }
}
