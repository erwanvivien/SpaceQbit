using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Obj;

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

    private Transform _objectToPlace;
    [SerializeField] private Camera _cam;

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
        _cam = GameObject.FindWithTag("PCamera(clone)").GetComponent<Camera>();
    }

    float GetCooToAngle(Vector3 target)
    {
        Vector3 targetDir = target - transform.position;
        targetDir.y = 0;
        float angle = Vector3.Angle(targetDir, new Vector3(1, 0, 0));

        return angle;
    }

    void Update()
    {
        if ((_lastTimeShoot + _cooldownShoot < Time.time) &&
            (!_shotable))
        {
            _shotable = true;
        }

        if (esc.inMenu)
        {
            return;
        }

        if (Input.GetMouseButton(0) && _shotable)
        {
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            float angle = 0;

            if (Physics.Raycast(ray, out hitInfo))
            {
                angle = GetCooToAngle(hitInfo.point);
                angle = Input.mousePosition.y > (float) Screen.height / 2 ? angle : -angle;
            }

            _posCanvas = GetComponentInParent<Transform>();

            GameObject newOne = Instantiate(Obj);

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
                0,
                (float) Math.Sin(angle));

            rb.velocity *= _bulletSpeed;

            Bullet_Collision bulletCollision = newOne.GetComponent<Bullet_Collision>();
            bulletCollision.SetDamage(_damage);

            _bullets.Add(newOne);
            _timeBullets.Add(Time.time);

            _shotable = false;
            _lastTimeShoot = Time.time;
        }

        if (_timeBullets.Count > 0 && (_timeBullets[0] + _durationBullet < Time.time))
        {
            _timeBullets.RemoveAt(0);
            _bullets.RemoveAt(0);
        }

        for (int i = 0; i < _bullets.Count; i++)
        {
            Bullet_Collision nvScript = _bullets[i].GetComponent<Bullet_Collision>();

            if (nvScript.GetCollision())
            {
                Destroy(_bullets[i]);

                _timeBullets.RemoveAt(i);
                _bullets.RemoveAt(i);
            }
        }

        if (_timeDuration < 0)
        {
            if (!_damageBoosted)
            {
                _damage /= _boostDamageBullet;
                _damageBoosted = true;
            }

            _timeDuration = 0;
        }

        if (Input.GetKeyDown(KeyCode.R) && _timeCooldown <= 0)
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