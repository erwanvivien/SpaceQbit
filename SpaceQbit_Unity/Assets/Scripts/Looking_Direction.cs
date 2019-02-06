using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    public GameObject canvas;
    private Rigidbody rigid;
    private Animator anm;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = canvas.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posMouse = Input.mousePosition;
        
        posMouse.y -= 400;
        posMouse.x -= 960;
        
        Debug.Log(posMouse);

        /*if (rigid.velocity == Vector3.zero) ;
        //anm.Play("player_rest");
        else
        {
            if (Math.Abs(posMouse.x) > Math.Abs(posMouse.y))
            {
                if (posMouse.x > 0)
                    anm.Play("player_left");
                else
                {
                    anm.Play("player_right");
                }
            }
            else
            {
                if (posMouse.y > 0)
                    anm.Play("player_up");
                else
                {
                    anm.Play("player_down");
                }
            }
        }*/
    }
}
