using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBuffs : MonoBehaviour
{
    public static int SpeedStat;
    public static int LifeStat;
    public static int RegenStat;
    public static int CooldownStat;

    public void AddSpeedStat()
    {
        if (!Check(100000)) return;
        SpeedStat++;
    }

    public void AddLifeStat()
    {
        if (!Check(100000)) return;
        LifeStat++;
    }

    public void AddRegenStat()
    {
        if (!Check(100000)) return;
        RegenStat++;
    }
    
    public void AddCooldownStat()
    {
        if (!Check(100000)) return;
        CooldownStat++;
    }

    private bool Check(int amount)
    {
        return SpeedStat + LifeStat + RegenStat + CooldownStat < 50 && GoldAccount.instance.RemoveGold(amount);
    }
}
