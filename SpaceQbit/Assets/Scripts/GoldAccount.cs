using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SpatialTracking;
using UnityEngine.UI;

public class GoldAccount : MonoBehaviour
{
    public static GoldAccount instance;

    public int gold = 0;
    public int silver = 0;
    public int copper = 0;
    public int total = 0;
    private int nbPlay = 0;

    private Text _goldText, _silverText, _copperText;
    private AudioSource _source;

    private void Start()
    {
        _goldText = GetComponentsInChildren<Text>()[0];
        _silverText = GetComponentsInChildren<Text>()[1];
        _copperText = GetComponentsInChildren<Text>()[2];
        UpDt();

        _source = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddGold(int award)
    {
        gold += award / 10000;
        silver += (award % 10000) / 100;
        copper += award % 100;

        CheckGold();
        UpDt();
    }


    public void AddGold(int g, int s, int c)
    {
        gold += g;
        silver += s;
        copper += c;

        CheckGold();
        UpDt();
    }

    public bool RemoveGold(int lessen)
    {
        if (total < lessen) return false;

        total -= lessen;
        gold = (total / 10000) % 100;
        silver = (total % 10000) / 100;
        copper = total % 100;

        CheckGold();
        UpDt();

        return true;
    }

    public bool RemoveGold(int g, int s, int c)
    {
        return RemoveGold(g * 10000 + s * 100 + c);
    }

    private void CheckGold()
    {
        while (copper >= 100)
        {
            copper -= 100;
            silver++;
        }

        while (silver >= 100)
        {
            silver -= 100;
            gold++;
        }

        if (gold >= 100000)
        {
            gold = 99999;
        }

        nbPlay++;
    }


    public void UpDt()
    {
        _copperText.text = copper.ToString().PadLeft(2, '0');

        _silverText.text = silver.ToString().PadLeft(2, '0');

        _goldText.text = gold.ToString().PadLeft(5, '0');
    }

    private void Update()
    {
        total = gold * 10000 + silver * 100 + copper;
        if (_source.isPlaying || nbPlay <= 0) return;

        nbPlay--;
        _source.Play();
    }
}