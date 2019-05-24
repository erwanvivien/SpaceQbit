using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBuffs : MonoBehaviour
{
    public static int SpeedStat;
    public static int LifeStat;
    public static int RegenStat;
    public static int CooldownStat;

    public static void AddSpeedStat()
    {
        if (!Check(100000)) return;
        SpeedStat++;
    }

    public static void AddLifeStat()
    {
        if (!Check(100000)) return;
        LifeStat++;
    }

    public static void AddRegenStat()
    {
        if (!Check(100000)) return;
        RegenStat++;
    }
    
    public static void AddCooldownStat()
    {
        if (!Check(100000)) return;
        CooldownStat++;
    }

    private static bool Check(int amount)
    {
        return SpeedStat + LifeStat + RegenStat + CooldownStat < 50 && GoldAccount.instance.RemoveGold(amount);
    }
}
