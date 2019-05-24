using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunBuffs : MonoBehaviour
{
    public static int DamageStat;
    public static int TickStat;
    public static int SpeedBulletStat;

    public void AddDamageStat()
    {
        if (!Check(100000)) return;
        DamageStat++;
    }

    public void AddTickStat()
    {
        if (!Check(100000)) return;
        TickStat++;
    }

    public void AddBulletSpeedStat()
    {
        if (!Check(100000)) return;
        SpeedBulletStat++;
    }

    private bool Check(int amount)
    {
        if (DamageStat + TickStat + SpeedBulletStat >= 50) return false;
        return GoldAccount.instance.RemoveGold(amount);
    }
}