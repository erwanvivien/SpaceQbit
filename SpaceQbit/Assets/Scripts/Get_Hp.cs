using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Get_Hp : MonoBehaviour
{
    [SerializeField] private float maxLife = 100;

    [NonSerialized] public float Life;
    private Vector3 _maxScale;

    private float _time;
    [NonSerialized] public float Cooldown;

    public void Damaged(float dmg)
    {
        _time = Cooldown;
        Set(Life - dmg);
    }


    private void Start()
    {
        Cooldown = 3f;
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

    private void Update()
    {
        if (_time <= 0)
        {
            _time = Cooldown;
            Set(Life + maxLife / 50);
        }

        if (Life <= 0)
        {
            GoldAccount.instance.gold /= 10;
            Life = 0;
        }

        _time -= Time.deltaTime;
    }
}