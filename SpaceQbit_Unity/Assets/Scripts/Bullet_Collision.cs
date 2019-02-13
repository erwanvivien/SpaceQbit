using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    private bool _collision;
    
    private void OnCollisionEnter(Collision other)
    {
        string tags = other.gameObject.tag;
        if (tags != "Frame_Perso" && tags != "Terrain" || tags == "Mur")
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
