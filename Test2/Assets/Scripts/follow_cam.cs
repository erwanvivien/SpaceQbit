using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_cam : MonoBehaviour
{
    //public Cube cube;
    public GameObject obj;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - obj.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = obj.transform.position + offset;
        transform.position = new Vector3(obj.transform.position.x, obj.transform.position.y + 3, obj.transform.position.z - 2);
    }
}