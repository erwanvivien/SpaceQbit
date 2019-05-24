using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.Experimental.UIElements.Button;

public class cheats : MonoBehaviour
{
    private string[] cheatCodes = new[] {"gold", "buff", "die"};
    private string tmp = "";

    void Update()
    {
        var i = 0;
        for (; i < tmp.Length; i++)
        {
            var f = false;
            foreach (var q in cheatCodes)
            {
                if (tmp[i] == q[i])
                {
                    f = true;
                }
            }

            if (!f)
            {
                tmp = "";
            }
        }

        if (i == tmp.Length)
        {
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
                        MerchantTrigger.instance.UpdateText();
                        break;
                    case "die" :
                        GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>().Set(0);
                        break;
                    /**
                     * ADD CASES : (And in the cheatCodes array
                     */
                }
                tmp = "";
            }
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