using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class SaveGame : MonoBehaviour
{
    public void Save()
    {
        var output = "";
        {
            var tmp = GameObject.FindWithTag("Frame_Perso").GetComponent<Transform>().position;
            output += "" +
                      tmp.x + ':' +
                      tmp.y + ':' +
                      tmp.z + "\n";
            output += "\n";

            output += "" +
                      GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>().Life +
                      "\n";

            output += "\n";
        }
        {
            var tmp = GameObject.FindWithTag("Quest").GetComponentsInChildren<Transform>(true);

            for (var index = 1; index < tmp.Length; index++)
            {
                var q = tmp[index].gameObject.GetComponent<Quests>();
                output += "" +
                          q.questID + ':' +
                          q.done + ':' +
                          q.pickedUp + ':' +
                          q.howMany +
                          "\n";
            }

            output += "\n";
        }
        {
            var tmp = GameObject.FindWithTag("Enemies").GetComponentsInChildren<Transform>(true);
            for (var index = 1; index < tmp.Length; index += 2)
            {
                output += "" +
                          tmp[index].gameObject.activeSelf + ':' +
                          tmp[index].position.x + ':' +
                          tmp[index].position.y + ':' +
                          tmp[index].position.z + ":" +
                          tmp[index].gameObject.GetComponent<Killable>().life +
                          "\n";
            }

            output += "\n";
        }
        {
            output += "" +
                      GoldAccount.instance.gold + ':' +
                      GoldAccount.instance.silver + ':' +
                      GoldAccount.instance.copper +
                      "\n";

            output += "\n";
        }


        /*
         * MANQUE LES BUFFS
         */

        using (StreamWriter sw = new StreamWriter("SaveGame.txt"))
        {
            sw.Write(output);
        }
    }

    private void Start()
    {
        if (!LoadOptions.UsingSave) return;

        var s = "";
        using (StreamReader sr = new StreamReader("SaveGame.txt"))
        {
            s = sr.ReadToEnd();
        }

        var lines = s.Split('\n').ToList();

        {
            var x = lines[0].Split(':');
            var tmp = new Vector3(float.Parse(x[0]), float.Parse(x[1]), float.Parse(x[2]));

            GameObject.FindWithTag("Frame_Perso").GetComponent<Transform>().position = tmp;
            gameObject.GetComponentsInChildren<Transform>()[1].position = tmp + new Vector3(0, 3, -3);
        }
        {
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>().Life = int.Parse(lines[0]);
        }
        {
            lines.RemoveAt(0);
            lines.RemoveAt(0);

            var tmp = GameObject.FindWithTag("Quest").GetComponentsInChildren<Transform>();
            for (var index = 1; index < tmp.Length; index++)
            {
                var q = tmp[index].gameObject.GetComponent<Quests>();
                var x = lines[0].Split(':');
                q.questID = Int32.Parse(x[0]);
                
                if (x[1].ToLower() == "true")
                {
                    q.DoneLoad();
                }

                if (x[2].ToLower() == "true")
                {
                    tmp[index].gameObject.SetActive(false);
                    q.Activate(true);
                }

                q.howMany = Int32.Parse(x[3]);

                lines.RemoveAt(0);
            }

            lines.RemoveAt(0);
        }
        {
            var tmp = GameObject.FindWithTag("Enemies").GetComponentsInChildren<Transform>();
            for (var index = 1; index < tmp.Length; index += 2)
            {
                var x = lines[0].Split(':');
                if (x[0].ToLower() == "false")
                    tmp[index].gameObject.SetActive(false);
                else
                {
                    tmp[index].position = new Vector3(float.Parse(x[1]), float.Parse(x[2]), float.Parse(x[3]));
                    tmp[index].gameObject.GetComponent<Killable>().life = int.Parse(x[4]);
                }

                lines.RemoveAt(0);
            }

            lines.RemoveAt(0);
        }
        {
            var x = lines[0].Split(':');
            GoldAccount.instance.gold = Int32.Parse(x[0]);
            GoldAccount.instance.silver = Int32.Parse(x[1]);
            GoldAccount.instance.copper = Int32.Parse(x[2]);
            
            GoldAccount.instance.UpDt();
        }
    }
}