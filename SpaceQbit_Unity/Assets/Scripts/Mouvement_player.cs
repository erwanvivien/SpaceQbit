using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class Mouvement_player : MonoBehaviour
{
    private float lastTimeDash;
    private float lastTimePressed;

    private bool dashable = true;

    private KeyCode lastKeyPressed;

    public Camera mainCam;    

    // ----------------------------

    public float getLastTimeDash()
    {
        return lastTimeDash;
    }

    public bool getDashable()
    {
        return dashable;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
                
        if (lastTimeDash + 5 < Time.time && !dashable)
        {
            dashable = true;
        }        
        
        if (Input.GetKey(KeyCode.Z))
        {            
            mvt += Vector3.forward;
        }
     
        if (Input.GetKey(KeyCode.Q))
        {
            mvt += Vector3.left;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            mvt += Vector3.back;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            mvt += Vector3.right;
        }
        if (Math.Abs(mvt.x) + Math.Abs(mvt.z) == 1)
            mvt *= 1.42f;
        //Debug.Log(mvt);
        transform.position += mvt * dt;

        if ((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             dashable)
        {
            transform.position += mvt;
            lastTimeDash = Time.time;
            dashable = false;
        }
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            Vector3 tmp = new Vector3(ray.direction.x, 0, ray.direction.z - 0.5f);
            transform.position += tmp * dt * 2f;
        }
    }
}
        