using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    private Animator _anm;
    private Mouvement_player _player;
    private Rigidbody _rigid;
    
    // Start is called before the first frame update
    void Start()
    {
        _anm = GetComponent<Animator>();
        
        _player = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();
        _rigid = GameObject.FindWithTag("Frame_Perso").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posMouse = Input.mousePosition;
        string animToplay;
        posMouse.y -= Screen.height / 2;
        posMouse.x -= Screen.width / 2;

        if (!_player.GetMoving())
        {
            if (posMouse.x >= 0)
            {
                animToplay = "player_rest";
            }
            else
            {
                animToplay = "player_rest_left";
            }
        }
        else
        {
            if (Math.Abs(posMouse.x) > Math.Abs(posMouse.y))
            {
                if (posMouse.x > 0)
                {
                    if (_rigid.velocity.x >= 0)
                    {
                        animToplay = "player_right_right";
                    }
                    else
                    {
                        animToplay = "player_left_right";
                    }
                }
                else
                {
                    if(_rigid.velocity.x >= 0)
                    {
                        animToplay = "player_left_left";
                    }
                    else
                    {
                        animToplay = "player_right_left";
                    }
                }
            }
            else
            {
                if (posMouse.y > 0)
                    animToplay = "player_up";
                else
                {
                    animToplay = "player_down";
                }
            }
        }
        _anm.Play(animToplay);
    }
}
