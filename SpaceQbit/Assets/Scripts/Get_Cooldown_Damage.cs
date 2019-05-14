using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Cooldown_Damage : MonoBehaviour
{
    [SerializeField] private Shooting _otherScript;
    
    private float _dashed;
    
    private float _timer = 0;
    private float _cooldown;
    
    private float _time;

    void Start()
    {
        if(_otherScript == null)
            _otherScript = GameObject.FindWithTag("Gun").GetComponent<Shooting>();
        
        _cooldown = _otherScript.GetCooldownBulletSpell();
    }

    void Update()
    {
        var d = _otherScript.GetDamageBoosted();

        if (!d && _timer <= 0) 
        {
            _timer = _cooldown;
        }

        if (_timer < 0)
        {
            _timer = 0;
        }
        
        transform.localScale = (new Vector3(_timer / _cooldown * 200f, 200, 1));

        _timer -= Time.deltaTime;
    }
}
