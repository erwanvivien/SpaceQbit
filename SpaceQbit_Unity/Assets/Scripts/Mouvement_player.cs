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

    private KeyCode _lastKeyPressed;

    // ----------------------------

    public float GetLastTimeDash()
    {
        return _lastTimeDash;
    }

    public float GetCooldownDash()
    {
        return CooldownDash;
    }

    public bool GetDashable()
    {
        return _dashable;
    }

    public bool GetMoving()
    {
        return _moving;
    }

    void Update()
    {
        float dt = Time.deltaTime;
        
        Vector3 mvt = Vector3.zero;
        
        _moving = true;
        
        if (_lastTimeDash > CooldownDash && !_dashable)
        {
            _dashable = true;
        }
        
        mvt += new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        
        if (Math.Abs(mvt.x) + Math.Abs(mvt.z) == 1)
        {
            mvt *= 1.42f;
        }
        
        transform.position += mvt * dt;

        if (((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             _dashable))
        {
            transform.position += mvt;
            _lastTimeDash = 0;
            _dashable = false;
        }

        if (mvt == Vector3.zero)
        {
            _moving = false;
        }
        
        _lastTimeDash += dt;
    }
}
        