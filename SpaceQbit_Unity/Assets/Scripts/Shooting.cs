using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Obj;
    
    private Escape_Menu esc;


    
    
    
    private Transform _posCanvas;
    private List<GameObject> _bullets;
    private List<float> _timeBullets;
    
    private float _lastTimeShoot;
    private bool _shotable = true;
    private float _cooldownShoot;
    private float _bulletSpeed;

    private float _durationBullet;
    
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


    
    // Start is called before the first frame update
    void Start()
    {
        _bulletSpeed = 3;
        _durationBullet = 10;
        _lastTimeShoot = -2;
        _bullets = new List<GameObject>();
        _timeBullets = new List<float>();
        _cooldownShoot = 0.5f;
        
        esc = GameObject.FindWithTag("Menu").GetComponent<Escape_Menu>();
    }

    float sign(float x)
    {
        if (x >= 0) return 1;
        return -1;
    }

    float GetCooToAngle()
    {
        Vector3 posMouse = Input.mousePosition;
        posMouse.x -= (Screen.width / 2);
        posMouse.y -= (Screen.height / 2);
        
        double a = Math.Atan2(posMouse.y, posMouse.x) * 180 / Math.PI;
        
        return (float) a;
    }

    void Update()
    {
        if ((_lastTimeShoot + _cooldownShoot < Time.time) &&
            (!_shotable))
        {
            _shotable = true;
        }
        
        if (esc.getOn())
        {
            return;
        }

        if (Input.GetMouseButton(0) && _shotable)
        {
            _posCanvas = GetComponentInParent<Transform>();

            GameObject newOne = Instantiate(Obj);
            
            newOne.transform.localPosition = _posCanvas.position;

            float angle = GetCooToAngle();

            Transform sprite = newOne.GetComponentInChildren<Transform>();   
            sprite.Rotate(0 , 0, angle - 90);
            
            Rigidbody rb = newOne.GetComponent<Rigidbody>();
            
            angle = (angle % 360 + 360) % 360;
            angle = (float) (angle / 180 * Math.PI);
            
            rb.velocity = new Vector3((float) Math.Cos(angle), 
                                        0 , 
                                        (float) Math.Sin(angle));
            rb.velocity *= _bulletSpeed;

            _bullets.Add(newOne);
            _timeBullets.Add(Time.time);

            _shotable = false;
            _lastTimeShoot = Time.time;
        }

        if (_timeBullets.Count > 0 && (_timeBullets[0] + _durationBullet < Time.time))
        {
            Destroy(_bullets[0]);
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
    }
}
