using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    private bool _collision;
    
    private void OnCollisionEnter(Collision other)
    {
        string tag = other.gameObject.tag;
        if (tag != "Frame_Perso" && tag != "Terrain" || tag == "Mur")
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
