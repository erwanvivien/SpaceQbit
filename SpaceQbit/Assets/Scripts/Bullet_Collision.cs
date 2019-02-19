using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Bullet_Collision : MonoBehaviour
{
    [SerializeField] private Shooting tmp;
    
    private bool _collision;
    
    public bool GetCollision()
    {
        return _collision;
    }

    private void Start()
    {
        if (tmp == null)
            tmp = GameObject.FindWithTag("Perso").GetComponent<Shooting>();
    }

    private void OnTriggerEnter(Collider other)
    {
        string tags = other.gameObject.tag;
        switch (tags)
        {
            case "Mur":
                _collision = true;
                break;

            case "Killable":
                int dmg = tmp.GetDamage();
                other.gameObject.GetComponent<Killable>().Attack(dmg);
                _collision = true;
                break;
            
            default:
                _collision = false;
                break;
        }
    }
}