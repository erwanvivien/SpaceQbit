using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    private bool _collision;

    private void OnTriggerEnter(Collider other)
    {
        string tags = other.gameObject.tag;
        switch (tags)
        {
<<<<<<< HEAD
            case "Mur":
                _collision = true;
                break;
                
            case "Killable":
//                other.gameObject.GetComponent<Life>().Attack(damage);
                _collision = true;
                break;
                
            default:
                _collision = false;
                break;
=======
                case "Mur":
                    _collision = true;
                    break;
                
                case "Killable":
//                    other.gameObject.GetComponent<Life>().Attack(damage);
                    _collision = true;
                    break;
                
                default:
                    _collision = false;
                    break;
>>>>>>> 70c98b4e9753ed38e8a170cce6d09cd0b997b85e
        }
        if (tags == "Mur" || (tags != "Frame_Perso" && tags != "Terrain"))
        {
            _collision = true;
        }
    }

    public bool GetCollision()
    {
        return _collision;
    }
}