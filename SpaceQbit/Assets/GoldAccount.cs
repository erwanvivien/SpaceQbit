using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.SpatialTracking;
using UnityEngine.UI;

public class GoldAccount : MonoBehaviour
{
    public static GoldAccount instance;

    private int gold = 0, silver = 0, copper = 0;

    private Text goldText, silverText, copperText;

    private void Start()
    {
        goldText = GetComponentsInChildren<Text>()[0];
        silverText = GetComponentsInChildren<Text>()[1];
        copperText = GetComponentsInChildren<Text>()[2];
        UpDt();
    }

    private void Awake()
    {
        instance = this;
    }

    public void AddGold(int award)
    {
        gold += (award / 10000) % 100;
        silver += (award % 10000) / 100;
        copper += award % 100;

        CheckGold();
        UpDt();
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
    }

    public void AddGold(int g, int s, int c)
    {
        gold += g;
        silver += s;
        copper += c;

        CheckGold();
        UpDt();
    }

    public void RemoveGold(int lessen)
    {
    }


    private void UpDt()
    {
        goldText.text = gold.ToString().PadLeft(5, '0');
        silverText.text = silver.ToString().PadLeft(2, '0') + "     ";
        copperText.text = copper.ToString().PadLeft(2, '0');
    }
}