using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    [SerializeField] private Animator _anm;
    [SerializeField] private Mouvement_player _player;

    public AudioClip decol;
    public AudioClip atter;

    private AudioSource _audioSource;

    private Vector3 _scaling;
    private Vector3 _posGun;
    private Vector3 _scaleGun;

    private bool _hasRunned;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_anm == null)
            _anm = GetComponent<Animator>();
        if(_player == null)
            _player = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();

        _audioSource = GetComponent<AudioSource>();
        
        _scaling = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        var posMouse = Input.mousePosition;
        string animToPlay;
        
        posMouse.y -= Screen.height / 2f;
        posMouse.x -= Screen.width / 2f;

        if (_player.GetMoving())
        {
            if (!_hasRunned)
            {
                _hasRunned = true;
                animToPlay = "player_decol";
                _audioSource.clip = decol;
                _audioSource.Play();
            }
            else
            {
                animToPlay = "player_moving";
            }
        }
        else
        {
            if (_hasRunned)
            {
                _hasRunned = false;
                animToPlay = "player_atter";
            }
            else
            {
                animToPlay = "player_rest";
            }
        }

        transform.localScale = new Vector3(Math.Sign(posMouse.x) >= 0 ? _scaling.x : -_scaling.x, 
            _scaling.y, 
            _scaling.z);
        
        _anm.Play(animToPlay);
    }
}