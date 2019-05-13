using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Obj;

    public AudioSource audio;
    
    private CurrentMenu esc;

    private Transform _posCanvas;
    private List<GameObject> _bullets;
    private List<float> _timeBullets;
    
    private float _lastTimeShoot;
    private bool _shotable = true;
    
    [SerializeField] private float _cooldownShoot = 0.5f;
    [SerializeField] private float _bulletSpeed = 3;

    [SerializeField] private float _durationBullet = 10;
    
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _cooldownBulletSpell = 10f;
    [SerializeField] private float _durationBulletSpell = 1f;
    [SerializeField] private int _boostDamageBullet = 3;

    private float _timeDuration;
    private float _timeCooldown;
    private bool _damageBoosted = true;

    private Transform objectToPlace;

    public bool GetDamageBoosted()
    {
        return _damageBoosted;
    }
    
    public float GetCooldownBulletSpell()
    {
        return _cooldownBulletSpell;
    }

    public int GetBoostDamagebullet()
    {
        return _boostDamageBullet;
    }
    
    public float GetLastTimeShoot()
    {
        return _lastTimeShoot;
    }

    public float GetCooldownShoot()
    {
        return _cooldownShoot;
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
        Vector3 pos = Input.mousePosition;
        pos -= new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        
        return (float) Math.Atan2(pos.y * 1.42f, pos.x) * 180 / (float) Math.PI;
    }

    void Update()
    {
        if ((_lastTimeShoot + _cooldownShoot < Time.time) &&
            (!_shotable)) // CHECKS THE COOLDOWN FOR THE SHOOTING
        {
            _shotable = true;
        }
        
        if (esc.InMenu()) // IF IN MENU THEN DO NOTHING
        {
            return;
        }

        if (Input.GetMouseButton(0) && _shotable) // INSTANTIATE A NEW AMO ON CLICK - WITH INFO : Who shot? Since When?
        {
            float angle = GetCooToAngle();
            
            _posCanvas = GetComponentInParent<Transform>();
            
            GameObject newOne = Instantiate(Obj); // INSTANTIATE A NEW AMO
            newOne.SetActive(true);
            newOne.transform.localPosition = _posCanvas.position;

            if (!_damageBoosted)
            {
                newOne.transform.GetChild(0).localScale *= 2;
                newOne.GetComponent<BoxCollider>().size *= 2;
            }
            
            Rigidbody rb = newOne.GetComponent<Rigidbody>();
            
            angle = (angle % 360 + 360) % 360;
            angle = (float) (angle / 180 * Math.PI);
            
            rb.velocity = new Vector3((float) Math.Cos(angle), 
                                        0 , 
                                        (float) Math.Sin(angle)) * _bulletSpeed;

            Bullet_Collision bulletCollision = newOne.GetComponent<Bullet_Collision>();
            bulletCollision.tmp = gameObject.GetComponentsInParent<Transform>()[1].gameObject; // PUTS THE MOVING FRAME AS THE SHOOTER OF THIS AMO
            bulletCollision.SetDamage(_damage);

            _bullets.Add(newOne);
            _timeBullets.Add(Time.time);

            _shotable = false;
            _lastTimeShoot = Time.time;

            audio.Play();
        }

        if (_timeBullets.Count > 0 && (_timeBullets[0] + _durationBullet < Time.time)) // IF BULLET IS THERE MORE THAN _durationBullet (secs)
        {
            _timeBullets.RemoveAt(0);
            _bullets.RemoveAt(0);
        }

        for (int i = 0; i < _bullets.Count; i++) // CHECK IF BULLET IS DESTROYED
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
                _damage /= _boostDamageBullet;
                _damageBoosted = true;
            }
            
            _timeDuration = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && _timeCooldown <= 0) // SET UP THE DAMAGE BOOST
        {
            _damageBoosted = false;
            _timeDuration = _durationBulletSpell;
            _timeCooldown = _cooldownBulletSpell;
            _damage *= _boostDamageBullet;
        }

        _timeDuration -= Time.deltaTime;
        _timeCooldown -= Time.deltaTime;
    }
}
