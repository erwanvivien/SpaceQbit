using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class Mouvement_player : MonoBehaviour
{
    private float CooldownDash = 5f;
    
    private float _lastTimeDash;
    private float _lastTimePressed;

    private bool _dashable = true;
    private bool _moving;

    private KeyCode lastKeyPressed;

    // ----------------------------

    public float getLastTimeDash()
    {
        return _lastTimeDash;
    }

    public float getCooldownDash()
    {
        return CooldownDash;
    }

    public bool getDashable()
    {
        return _dashable;
    }

    public bool getMoving()
    {
        return _moving;
    }

    // Start is called before the first frame update
    void Start()
    {
        _lastTimeDash = 0;
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
        _moving = true;
                
        if (_lastTimeDash + CooldownDash < Time.time && !_dashable)
        {
            _dashable = true;
        }        
        
        mvt += new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        
        if (Math.Abs(mvt.x) + Math.Abs(mvt.z) == 1)
        {
            mvt *= 1.42f;
        }
        
        transform.position += mvt * dt;

        if ((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             _dashable)
        {
            Ray r = new Ray(transform.position, transform.position + mvt);
            
            bool pathAvailable = true; // CHANGER CA POUR CHECK!
            
            if (pathAvailable)
            {
                transform.position += mvt;
                _lastTimeDash = Time.time;
                _dashable = false;
            }
        }

        Ray ray = new Ray(transform.position, transform.position + mvt);
        
        if (mvt == Vector3.zero)
        {
            _moving = false;
        }
    }
}
        