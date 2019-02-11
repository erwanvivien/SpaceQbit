using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class Mouvement_player : MonoBehaviour
{
    private float CooldownDash;
    
    private float lastTimeDash;
    private float lastTimePressed;

    private bool dashable = true;
    private bool moving = false;

    private KeyCode lastKeyPressed;

    public Camera mainCam;    

    // ----------------------------

    public float getLastTimeDash()
    {
        return lastTimeDash;
    }

    public float getCooldownDash()
    {
        return CooldownDash;
    }

    public bool getDashable()
    {
        return dashable;
    }

    public bool getMoving()
    {
        return moving;
    }

    // Start is called before the first frame update
    void Start()
    {
        CooldownDash = 5f;
    }

    private void OnCollisionEnter(Collision other)
    {
        //throw new System.NotImplementedException();
    }

    // Update is called once  frame
    void Update()
    {
        float dt = Time.deltaTime;
        Vector3 mvt = Vector3.zero;
                
        if (lastTimeDash + CooldownDash < Time.time && !dashable)
        {
            dashable = true;
        }        
        
        if (Input.GetKey(KeyCode.Z) || (Input.GetKey(KeyCode.LeftAlt)))
        {            
            mvt += Vector3.forward;
            moving = true;
        }
     
        if (Input.GetKey(KeyCode.Q))
        {
            mvt += Vector3.left;
            moving = true;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            mvt += Vector3.back;
            moving = true;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            mvt += Vector3.right;
            moving = true;
        }
        
        if (Math.Abs(mvt.x) + Math.Abs(mvt.z) == 1)
            mvt *= 1.42f;
        
        transform.position += mvt * dt;

        if ((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             dashable)
        {
            transform.position += mvt;
            lastTimeDash = Time.time;
            dashable = false;
        }        
        
        if(mvt == Vector3.zero)
            moving = false;
    }
}
        