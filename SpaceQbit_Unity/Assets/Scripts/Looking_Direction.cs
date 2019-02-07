using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    private Animator anm;
    private Mouvement_player player;
    
    // Start is called before the first frame update
    void Start()
    {
        anm = GetComponent<Animator>();
        
        player = GameObject.FindWithTag("Frame").GetComponent<Mouvement_player>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posMouse = Input.mousePosition;
        
        posMouse.y -= 400;
        posMouse.x -= 967;
        
        Debug.Log(posMouse);

        if (!player.getMoving())
        {
            anm.Play("player_rest");
        }
        else
        {
            if (Math.Abs(posMouse.x) > Math.Abs(posMouse.y))
            {
                if (posMouse.x < 0)
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
        }
    }
}
