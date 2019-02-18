using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class Mouvement_player : MonoBehaviour
{
    private EscapeMenu esc;
    
    private float _cooldownDash = 5f;
    
    private float _lastTimeDash;
    private float _lastTimePressed;

    private bool _dashable = true;
    private bool _moving;

    private bool _speeding;
    private float _lastTimeMoveSpeed;
    private float _moveSpeed = 3;
    private float _durationMoveSpeed = 0.5f;

    private KeyCode _lastKeyPressed;

    // ----------------------------

    public float GetLastTimeDash()
    {
        return _lastTimeDash;
    }

    public float GetCooldownDash()
    {
        return _cooldownDash;
    }

    public bool GetDashable()
    {
        return _dashable;
    }

    public bool GetMoving()
    {
        return _moving;
    }

    private void Start()
    {
        esc = GameObject.FindWithTag("Menu").GetComponent<EscapeMenu>();
    }

    void Update()
    {
        if (esc.GetOn())
        {
            _moving = false;
            _dashable = true;
            _speeding = false;

            return;
        }

        
        float dt = Time.deltaTime;
        
        Vector3 mvt = Vector3.zero;
        
        _moving = true;
        
        if (_lastTimeDash > _cooldownDash && !_dashable)
        {
            _dashable = true;
            _speeding = false;
        }
                
        mvt += new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        
        if (mvt == Vector3.zero)
        {
            _moving = false;
        }
                
        if (Math.Abs(mvt.x) + Math.Abs(mvt.z) == 1)
        {
            mvt *= 1.42f;
        }
        
        if (((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             _dashable))
        {
            _lastTimeDash = 0;
            _lastTimeMoveSpeed = 0;
            _dashable = false;
            _speeding = true;
        }

        if (_lastTimeMoveSpeed < _durationMoveSpeed && _speeding)
        {
            transform.position += mvt * dt * _moveSpeed;
        }
        else
        {
            transform.position += mvt * dt;
        }

        
        _lastTimeDash += dt;
        _lastTimeMoveSpeed += dt;
    }
}
        