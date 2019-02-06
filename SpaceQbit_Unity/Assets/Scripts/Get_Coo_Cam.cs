using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Coo_Cam : MonoBehaviour
{
    public GameObject CanvasCam;

    private Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(1.43f, 3.43f, -2);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = CanvasCam.transform.position - offset;
    }
}
