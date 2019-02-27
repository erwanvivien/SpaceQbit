using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Collision : MonoBehaviour
{
    [FormerlySerializedAs("tmp")] [SerializeField] private Shooting _tmp;

    private int _damage;
    
    private bool _collision;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }
    
    public bool GetCollision()
    {
        return _collision;
    }

    private void Start()
    {
        if (_tmp == null)
            _tmp = GameObject.FindWithTag("Perso").GetComponent<Shooting>();
    }

    private void OnTriggerStay(Collider other)
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
}