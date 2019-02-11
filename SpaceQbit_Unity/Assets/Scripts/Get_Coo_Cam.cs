using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Get_Coo_Cam : MonoBehaviour
{
    public GameObject CanvasCam;

    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
//        Debug.Log(Screen.height);
//        Debug.Log(Screen.width);
//        
//        float angle = (float) Math.Atan2(Screen.height, Screen.width);
//        Debug.Log(angle);
        
        offset = new Vector3(1.43f, 3.43f, -2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CanvasCam.transform.position - offset;
    }
}
