using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Follow: MonoBehaviour
{
    private Vector3 b = Vector3.zero;

    public GameObject obj;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - obj.transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = obj.transform.position;

        targetPosition += offset;
        
        transform.position = 
            Vector3.SmoothDamp(transform.position, 
                targetPosition, 
                ref b, 
                0.5f);
    }
}