using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBuffs : MonoBehaviour
{
    public static int SpeedStat;
    public static int LifeStat;
    public static int OtherStat;

    public static void AddDamageStat()
    {
        if (!Check(100000)) return;
        SpeedStat++;
    }

    public static void AddTickStat()
    {
        if (!Check(100000)) return;
        LifeStat++;
    }

    public static void AddOtherStat()
    {
        if (!Check(100000)) return;
        OtherStat++;
    }

    private static bool Check(int amount)
    {
        return SpeedStat + LifeStat + OtherStat < 50 && GoldAccount.instance.RemoveGold(amount);
    }
}
