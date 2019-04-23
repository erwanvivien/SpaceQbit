using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D;

public class PositionDrone : MonoBehaviour
{
    float GetCooToAngle()
    {
        Vector3 pos = Input.mousePosition;
        pos -= new Vector3(Screen.width / 2f, Screen.height / 2f, 0);
        
        return (float) Math.Atan2(pos.y * 1.42f, pos.x) ;
    }

    // Update is called once per frame
    void Update()
    {
        float angle = GetCooToAngle();

        GameObject o;
        (o = gameObject).transform.position = 
            new Vector3((float) Math.Cos(angle), 0, (float) Math.Sin(angle) ) / 1.5f 
            + GetComponentsInParent<Transform>()[1].position;
        
        o.transform.localEulerAngles = (new Vector3(45, 0, (float) (angle * 180 / Math.PI) - 90));
    }
}
