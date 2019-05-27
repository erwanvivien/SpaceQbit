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

public class Get_Hp : MonoBehaviour
{
    [SerializeField] private float maxLife = 100;
    private float _maxLifeInGame;

    public UnityEngine.UI.Image panel;

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
        panel = GameObject.FindWithTag("dyingpannel").GetComponent<UnityEngine.UI.Image>();

        Cooldown = 3f;
        
        _maxLifeInGame = maxLife;
        Life = maxLife;
        
        _maxScale = gameObject.transform.localScale;
        if (_maxScale == Vector3.zero)
        {
            _maxScale = new Vector3(1, 1, 1);
        }
    }

    public void Setup()
    {
        _maxLifeInGame = maxLife;
    }


    public void Set(float life)
    {
        life = life < 0 ? 0 : life;
        life = life > _maxLifeInGame ? _maxLifeInGame : life;

        Life = life;
        gameObject.transform.localScale = new Vector3(Life / _maxLifeInGame * _maxScale.x, _maxScale.y, _maxScale.z);
    }

    private void Update()
    {
        _maxLifeInGame = (float) (maxLife * Math.Pow(1.04, CharBuffs.LifeStat));
        Cooldown = (float) (3 * Math.Pow(0.98, CharBuffs.RegenStat));
        
        if (_time <= 0)
        {
            _time = Cooldown;
            CurrentMenu._inVendor = false;
            panel.transform.localScale = new Vector3(0, 1, 1);
            Set(Life + _maxLifeInGame / 50);
        }

        if (Life <= 0)
        {
            CurrentMenu._inVendor = true;
            GoldAccount.instance.RemoveGold(GoldAccount.instance.gold * 2500);
            _time = Cooldown;
            panel.transform.localScale = new Vector3(1, 1, 1);

            Life = _maxLifeInGame;
            GameObject.FindWithTag("Frame_Perso").GetComponent<Transform>().position =
                new Vector3(Map.posX, Map.posY, Map.posZ);
        }

        _time -= Time.deltaTime;
    }
}