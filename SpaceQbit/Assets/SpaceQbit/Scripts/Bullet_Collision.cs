using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Collision : MonoBehaviour
{
    [SerializeField] private int   _damage       = 10 ;
    [SerializeField] private float _cooldown     = 10;
    [SerializeField] private int   _boostDamage = 3;

    private float _time = 0;
    private bool _pressed = false;
    
    private bool _collision;

    private void OnTriggerEnter(Collider other)
    {
        string tags = other.gameObject.tag;
        switch (tags)
        {
            case "Mur":
                _collision = true;
                break;

            case "Killable":
                other.gameObject.GetComponent<Killable>().Attack(_damage);
                _collision = true;
                break;

            default:
                _collision = false;
                break;
        }
    }

    public bool GetCollision()
    {
        return _collision;
    }

    private void Update()
    {       
        if (_time < 0)
        {
            _damage /= _boostDamage;
            _time = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.R) && (_time <= 0f))
        {
            _time = _cooldown;
            _damage *= _boostDamage;
        }

        _time -= Time.deltaTime;
    }
}