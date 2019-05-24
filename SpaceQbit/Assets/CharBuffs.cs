using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharBuffs : MonoBehaviour
{
    public static int SpeedStat;
    public static int LifeStat;
    public static int OtherStat;

    public void AddDamageStat()
    {
        if (!Check(100000)) return;
        SpeedStat++;
    }

    public void AddTickStat()
    {
        if (!Check(100000)) return;
        LifeStat++;
    }

    public void AddOtherStat()
    {
        if (!Check(100000)) return;
        OtherStat++;
    }

    private bool Check(int amount)
    {
        if (SpeedStat + LifeStat + OtherStat >= 50) return false;
        return GoldAccount.instance.RemoveGold(amount);
    }
}
