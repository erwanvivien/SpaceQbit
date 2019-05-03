﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Get_Hp : MonoBehaviour
{
    [SerializeField] private float maxLife = 100;
    
    private float _life;
    private Vector3 _maxScale;

    public void Damaged(float dmg)
    {
        _life -= dmg;
        _life = _life < 0 ? 0 : _life;
        
        /*
         * Need to add the death when life == 0 (Back to main screen)
         */
        
        gameObject.transform.localScale = new Vector3(_life/maxLife * _maxScale.x, _maxScale.y, _maxScale.z);
    }

    private void Start()
    {
        _life = maxLife;
        _maxScale = gameObject.transform.localScale;
    }
}
