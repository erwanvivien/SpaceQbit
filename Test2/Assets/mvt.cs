using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once  frame
    void Update()
    {
        bool jump = false;
        if(Input.GetKey(KeyCode.Z))
            gameObject.transform.Translate(Vector3.forward * Time.deltaTime);
        if(Input.GetKey(KeyCode.Q))
            gameObject.transform.Translate(Vector3.left * Time.deltaTime);
        if(Input.GetKey(KeyCode.S))
            gameObject.transform.Translate(Vector3.back * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
            gameObject.transform.Translate(Vector3.right * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) || jump)
        {
            jump = true;
        
            gameObject.transform.Translate(Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.X))
            jump = false;
    }
}
        