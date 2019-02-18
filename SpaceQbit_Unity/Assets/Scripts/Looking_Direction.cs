using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    private Animator _anm;
    private Mouvement_player _player;

    private Vector3 _scaling;
    
    // Start is called before the first frame update
    void Start()
    {
        _anm = GetComponent<Animator>();
        
        _player = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();

        _scaling = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posMouse = Input.mousePosition;
        string animToPlay;
        
        posMouse.y -= Screen.height / 2f;
        posMouse.x -= Screen.width / 2f;

        if (_player.GetMoving())
        {
            animToPlay = "player_moving";
        }
        else
        {
            animToPlay = "player_rest";
        }

        transform.localScale = new Vector3(Math.Sign(posMouse.x) >= 0 ? _scaling.x : -_scaling.x, 
            _scaling.y, 
            _scaling.z);
        
        _anm.Play(animToPlay);
    }
}