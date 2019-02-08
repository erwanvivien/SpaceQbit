using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject obj;
    public Camera mainCam;
    private Transform posCanvas;
    private List<GameObject> Balls;
    private List<float> timeBalls;
    
    private float lastTimeShoot;
    private bool Shootable = true;
    private float CooldownShoot;
    
    
    
    
    public float getLastTimeShoot()
    {
        return lastTimeShoot;
    }

    public float getCooldownShoot()
    {
        return CooldownShoot;
    }

    public bool getShootable()
    {
        return Shootable;
    }

    
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        lastTimeShoot = -2;
        Balls = new List<GameObject>();
        timeBalls = new List<float>();
        CooldownShoot = 0.5f;
    }

    float sign(float x)
    {
        if (x >= 0) return 1;
        return -1;
    }

    float GetCooToAngle()
    {
        Vector3 posMouse = Input.mousePosition;
        posMouse.x -= 961;
        posMouse.y -= 419;

        double a = Math.Atan2(posMouse.y, posMouse.x) * 180 / Math.PI;
        Debug.Log(a);

        return (float) (a - 90);
    }

    // Update is called once per frame
    void Update()
    {
        if ((lastTimeShoot + CooldownShoot < Time.time) &&
            (!Shootable))
        {
            Shootable = true;
        }

        if (Input.GetMouseButton(0) && Shootable)
        {
            posCanvas = GetComponentInParent<Transform>();

            GameObject newOne = Instantiate(obj);
            
            newOne.transform.localPosition = posCanvas.position;
            newOne.transform.Rotate(0, 0, GetCooToAngle());
            
            Balls.Add(newOne);
            timeBalls.Add(Time.time);

            Shootable = false;
            lastTimeShoot = Time.time;
        }

        if (timeBalls[0] + 10 < Time.time)
        {
            timeBalls.RemoveAt(0);
            Balls.RemoveAt(0);
        }
    }
}
