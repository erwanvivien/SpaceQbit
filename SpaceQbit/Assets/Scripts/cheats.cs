using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;

public class cheats : MonoBehaviour
{
    private string[] cheatCodes = {"gold", "buff", "die", "nobuff"};
    private string tmp = "";

    void Update()
    {
        while (tmp != "" && (from element in cheatCodes where element.Contains(tmp) select element).ToList().Count == 0)
        {
            tmp = tmp.Substring(1);
        }

        foreach (var q in cheatCodes)
        {
            if (tmp != q) continue;

            switch (tmp)
            {
                case "gold":
                    GoldAccount.instance.AddGold(1000000);
                    break;
                case "buff":
                    GunBuffs.SpeedBulletStat = 50;
                    GunBuffs.DamageStat = 50;
                    GunBuffs.TickStat = 50;
                    CharBuffs.LifeStat = 50;
                    CharBuffs.RegenStat = 50;
                    CharBuffs.CooldownStat = 50;
                    CharBuffs.SpeedStat = 50;
                    foreach (var qq in MerchantTrigger.instance)
                    {
                        qq.UpdateText();
                    }

                    break;
                case "nobuff":
                    GunBuffs.SpeedBulletStat = 0;
                    GunBuffs.DamageStat = 0;
                    GunBuffs.TickStat = 0;
                    CharBuffs.LifeStat = 0;
                    CharBuffs.RegenStat = 0;
                    CharBuffs.CooldownStat = 0;
                    CharBuffs.SpeedStat = 0;
                    foreach (var qq in MerchantTrigger.instance)
                    {
                        qq.UpdateText();
                    }

                    break;
                case "die":
                    GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>().Set(0);
                    break;
                /**
                 * ADD CASES : (And in the cheatCodes array
                 */
                default:
                    break;
            }

            tmp = "";
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            tmp += 'a';
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            tmp += 'b';
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            tmp += 'c';
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tmp += 'd';
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            tmp += 'e';
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            tmp += 'f';
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            tmp += 'g';
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            tmp += 'h';
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            tmp += 'i';
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            tmp += 'j';
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            tmp += 'k';
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            tmp += 'l';
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            tmp += 'm';
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            tmp += 'n';
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            tmp += 'o';
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            tmp += 'p';
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            tmp += 'q';
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            tmp += 'r';
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            tmp += 's';
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            tmp += 't';
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            tmp += 'u';
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            tmp += 'v';
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            tmp += 'w';
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            tmp += 'x';
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            tmp += 'y';
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            tmp += 'z';
        }
    }
}