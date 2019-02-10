using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Collision : MonoBehaviour
{
    private bool collision = false;
    
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Perso"))
        {
            collision = true;
        }
    }

    public bool GetCollision()
    {
        return collision;
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
