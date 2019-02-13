using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Follow: MonoBehaviour
{
    private Vector3 _b = Vector3.zero;

    public GameObject obj;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - obj.transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = obj.transform.position;

        targetPosition += _offset;
        
        transform.position = 
            Vector3.SmoothDamp(transform.position, 
                targetPosition, 
                ref _b, 
                0.5f);
    }
}