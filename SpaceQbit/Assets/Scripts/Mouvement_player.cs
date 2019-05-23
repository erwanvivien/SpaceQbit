using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Serialization;
using Debug = UnityEngine.Debug;

public class Mouvement_player : MonoBehaviour
{
    private CurrentMenu esc;
    
    [SerializeField] private float _cooldownDash = 5f;
    
    private float _lastTimeDash;
    private float _lastTimePressed;

    private bool _dashable = true;
    private bool _moving;

    private bool _speeding;
    private float _lastTimeMoveSpeed;
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private float moveSpeedDash = 2;
    [SerializeField] private float durationMoveSpeed = 0.5f;

    private AudioSource _source;
    [SerializeField] private AudioClip toka;
    [SerializeField] private AudioClip charge;
    
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
        _source = GetComponent<AudioSource>();
        esc = GameObject.FindWithTag("Menu").GetComponent<CurrentMenu>();
    }

    void Update()
    {
        if (esc.InMenu())
        {
            _moving = false;
            _dashable = true;
            _speeding = false;

            return;
        }
        
        var dt = Time.deltaTime;
        
        var mvt = Vector3.zero;
        
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
                
        if (Math.Abs(Math.Abs(mvt.x) + Math.Abs(mvt.z) - 1) < 0.01f)
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

            _source.clip = toka;
            _source.Play();
        }

        mvt *= moveSpeed;

        if (_lastTimeMoveSpeed < durationMoveSpeed && _speeding)
        {
            transform.position += mvt * dt * moveSpeedDash;
        }
        else
        {
            transform.position += mvt * dt;
        }

        
        _lastTimeDash += dt;
        _lastTimeMoveSpeed += dt;
    }
}
        