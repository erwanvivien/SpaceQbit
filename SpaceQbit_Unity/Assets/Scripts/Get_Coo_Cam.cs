using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Get_Coo_Cam : MonoBehaviour
{
    public GameObject CanvasCam;

    private Vector3 _offset;
    
    void Start()
    {
        _offset = new Vector3(1.43f, 3.43f, -2);
    }

    void Update()
    {
        transform.position = CanvasCam.transform.position - _offset;
    }
}
