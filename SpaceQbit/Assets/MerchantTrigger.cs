﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class MerchantTrigger : MonoBehaviour
{
    public Canvas _canv;
    public Text t1;
    public Text t2;
    public Text t3;

    private void OnCollisionEnter(Collision other)
    {
        CurrentMenu._inVendor = true;
        _canv.enabled = true;

        UpdateText();
    }

    public void UpdateText()
    {
        t1.text = "" +
                  "[" + GunBuffs.DamageStat + "] : " +
                  "Weapon tickrate" +
                  " buy for " +
                  "10 holocoins";
        t2.text = "" +
                  "[" + GunBuffs.TickStat + "] : " +
                  "Weapon damage" +
                  " buy for " +
                  "10 holocoins";
        t3.text = "" +
                  "[" + GunBuffs.SpeedBulletStat + "] : " +
                  "Weapon tickrate" +
                  " buy for " +
                  "10 holocoins";
    }
}