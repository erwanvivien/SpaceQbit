using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerchantTriggerChar : MonoBehaviour
{
    public Canvas canv;
    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;

    public static MerchantTriggerChar instance;
    
    private void Start()
    {
        instance = this;
    }

    private void OnCollisionEnter(Collision other)
    {
        CurrentMenu._inVendor = true;
        canv.enabled = true;

        UpdateText();
    }

    public void UpdateText()
    {
        t1.text = "" +
                  "[" + CharBuffs.SpeedStat + "] : " +
                  "Speed" +
                  " buy for " +
                  "10 holocoins";
        t2.text = "" +
                  "[" + CharBuffs.LifeStat + "] : " +
                  "Life" +
                  " buy for " +
                  "10 holocoins";
        t3.text = "" +
                  "[" + CharBuffs.RegenStat + "] : " +
                  "Regeneration" +
                  " buy for " +
                  "10 holocoins";
        t4.text = "" +
                  "[" + CharBuffs.CooldownStat + "] : " +
                  "Cooldown" +
                  " buy for " +
                  "10 holocoins";
    }
}
