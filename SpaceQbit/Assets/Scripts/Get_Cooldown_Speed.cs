using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Cooldown_Speed : MonoBehaviour
{
    [SerializeField] private Mouvement_player _otherScript;
    
    private float _dashed;
    
    private float _timer = 0;
    private float _cooldown;
    
    private float _time;

    void Start()
    {
        if(_otherScript == null)
            _otherScript = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();
        
        _cooldown = _otherScript.GetCooldownDash();
    }

    void Update()
    {
        var d = _otherScript.GetDashable();

        if (!d && _timer <= 0) 
        {
            _cooldown = _timer = (float) (_otherScript.GetCooldownDash() * Math.Pow(0.975, CharBuffs.CooldownStat));
        }

        if (_timer < 0)
        {
            _timer = 0;
        }
        
        transform.localScale = (new Vector3(_timer / _cooldown * 200f, 200f, 1));

        _timer -= Time.deltaTime;
    }
}
