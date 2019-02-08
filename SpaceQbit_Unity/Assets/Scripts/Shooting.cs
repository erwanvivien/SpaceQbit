using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject obj;
    public Camera mainCam;
    private Transform posCanvas;
    private List<GameObject> Balls;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float GetCooToAngle()
    {
        Vector3 posMouse = Input.mousePosition;
                
        Debug.Log(posMouse);
        
        float a = (float) Math.Atan(posMouse.y / posMouse.x) * 180;//d * 100;
        return (float) Math.Atan(posMouse.y / posMouse.x) * 180;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            posCanvas = GetComponentInParent<Transform>();

            GameObject newOne = Instantiate(obj);
            
            newOne.transform.localPosition = posCanvas.position;
            newOne.transform.Rotate(0, 0, GetCooToAngle());
            
            //Balls.Add(newOne);
        }

    }
}
