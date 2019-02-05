using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    private Vector3 b = Vector3.zero;

    //public Cube cube;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 3, obj.transform.position.z - 2);
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = obj.transform.position;

        targetPosition += new Vector3(0, 3.43f, -2);
        
        transform.position = 
            Vector3.SmoothDamp(transform.position, 
                targetPosition, 
                ref b, 
                0.5f);
    }
}