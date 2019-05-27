using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UdpKit;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.Experimental.UIElements.Image;

public class Get_HP_TP : MonoBehaviour
{
    [SerializeField] private float maxLife = 100;


    [NonSerialized] public float Life;
    private Vector3 _maxScale;


    private float _time;

    private void Start()
    {
        Life = maxLife;
        
        _maxScale = gameObject.transform.localScale;
        if (_maxScale == Vector3.zero)
        {
            _maxScale = new Vector3(1, 1, 1);
        }
    }

    public void Set(float life)
    {
        life = life < 0 ? 0 : life;
        life = life > maxLife ? maxLife : life;

        Life = life;
        gameObject.transform.localScale = new Vector3(Life / maxLife * _maxScale.x, _maxScale.y, _maxScale.z);
    }
}