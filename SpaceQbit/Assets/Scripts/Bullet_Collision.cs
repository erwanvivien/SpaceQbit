using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    [SerializeField] private int _damage = 0;
    
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
}