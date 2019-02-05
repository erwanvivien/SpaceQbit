using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getCooCam : MonoBehaviour
{
    public Camera cam;

    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = cam.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam.transform.position - offset;
    }
}
