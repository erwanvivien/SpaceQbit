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


    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
