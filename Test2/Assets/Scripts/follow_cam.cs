using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
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
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 3, obj.transform.position.z - 2);
    }
}