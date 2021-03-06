﻿using System;
using UnityEngine;

public class Cam_Follow: MonoBehaviour
{
    private Vector3 _b = Vector3.zero;

    public GameObject Obj;
    public static Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Obj.transform.position;
    }
    
    void LateUpdate()
    {
        var targetPosition = Obj.transform.position;

        targetPosition += _offset;
            
        transform.position = 
            Vector3.SmoothDamp(transform.position, 
                targetPosition, 
                ref _b, 
                (float) (0.5 * Math.Pow(0.98f, CharBuffs.SpeedStat)));
    }
}