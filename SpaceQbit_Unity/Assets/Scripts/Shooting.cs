using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Obj;
    public Camera cam;
    
    
    
    
    private Transform _posCanvas;
    private List<GameObject> _bullets;
    private List<float> _timeBullets;
    
    private float _lastTimeShoot;
    private bool _shootable = true;
    private float _cooldownShoot;

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
        return _shootable;
    }


    
    // Start is called before the first frame update
    void Start()
    {
        _durationBullet = 10;
        _lastTimeShoot = -2;
        _bullets = new List<GameObject>();
        _timeBullets = new List<float>();
        _cooldownShoot = 0.5f;
    }

    float sign(float x)
    {
        if (x >= 0) return 1;
        return -1;
    }

    float GetCooToAngle()
    {
        Vector3 posMouse = Input.mousePosition;
        posMouse.x -= Screen.width / 2;
        posMouse.y -= Screen.height / 2;
        
        double a = Math.Atan2(posMouse.y, posMouse.x) * 180 / Math.PI;
        Debug.Log(a);   
        
        return (float) a;
    }

    void Update()
    {
        if ((_lastTimeShoot + _cooldownShoot < Time.time) &&
            (!_shootable))
        {
            _shootable = true;
        }

        if (Input.GetMouseButton(0) && _shootable)
        {
            _posCanvas = GetComponentInParent<Transform>();

            GameObject newOne = Instantiate(Obj);
            
            newOne.transform.localPosition = _posCanvas.position;

            float angle = GetCooToAngle();

            Transform sprite = newOne.GetComponentInChildren<Transform>();   
            sprite.Rotate(0 , 0, angle - 90);
            
            newOne.AddComponent<Rigidbody>();
            Rigidbody rb = newOne.GetComponent<Rigidbody>();
            
            rb.velocity = new Vector3((float) Math.Cos(angle / 360 * Math.PI), 
                                        0 , 
                                        (float) Math.Sin(angle / 360 * Math.PI));
            
            rb.useGravity = false;
            
            _bullets.Add(newOne);
            _timeBullets.Add(Time.time);

            _shootable = false;
            _lastTimeShoot = Time.time;
        }

        if (_timeBullets.Count > 0 && (_timeBullets[0] + _durationBullet < Time.time))
        {
            Destroy(_bullets[0]);
            _timeBullets.RemoveAt(0);
            _bullets.RemoveAt(0);
        }

        foreach (var q in _bullets)
        {
            //q.rigidbody.
        }
    }
}
