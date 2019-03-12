using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Looking_Direction : MonoBehaviour
{
    [SerializeField] private Animator _anm;
    [SerializeField] private Mouvement_player _player;
    [SerializeField] private Transform _gun;

    private Vector3 _scaling;
    private Vector3 _posGun;
    private Vector3 _scaleGun;
    
    // Start is called before the first frame update
    void Start()
    {
        if(_anm == null)
            _anm = GetComponent<Animator>();
        if(_player == null)
            _player = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();
        if(_gun == null)
            _gun = GameObject.FindWithTag("Gun").GetComponent<Transform>();

        _scaling = transform.localScale;
        _posGun = _gun.transform.position - transform.position;
        _scaleGun = _gun.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posMouse = Input.mousePosition;

        posMouse.y -= Screen.height / 2f;
        posMouse.x -= Screen.width / 2f;

        var animToPlay = _player.GetMoving() ? "player_moving" : "player_rest";

        transform.localScale = new Vector3(Math.Sign(posMouse.x) >= 0 ? _scaling.x : -_scaling.x, 
            _scaling.y, 
            _scaling.z);
        
        _gun.localScale = new Vector3(Math.Sign(posMouse.x) >= 0 ? _scaleGun.x : -_scaleGun.x, 
            _scaleGun.y, 
            _scaleGun.z);
        
        _gun.localPosition = new Vector3(Math.Sign(posMouse.x) >= 0 ? _posGun.x : -_posGun.x, 
            _posGun.y, 
            _posGun.z);

        _anm.Play(animToPlay);
    }
}