using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class SaveGame : MonoBehaviour
{
    public void Save()
    {
        var output = "";

        var tmp1 = GameObject.FindWithTag("Frame_Perso").GetComponent<Transform>().position;
        output += "" +
                  tmp1.x + ':' +
                  tmp1.y + ':' +
                  tmp1.z + "\n";
        output += "\n";

        output += "" +
                  GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>()._life +
                  "\n";

        output += "\n";

        var tmp2 = QuestManager.allQuests;
        foreach (var q in tmp2)
        {
            output += "" +
                      q.questID + ':' +
                      q.type + ':' +
                      q.who + ':' +
                      q.howMany + ':';

            for (var index = 0; index < q.sentences.Length - 1; index++)
            {
                output += q.sentences[index] + '\t';
            }

            output += "" +
                      q.sentences[q.sentences.Length - 1] + ':' +
                      q.award + ':' +
                      q.done + ':' +
                      q.wannaRepeat + ':' +
                      q.pickedUp +
                      "\n";
        }

        output += "\n";

        var tmp4 = GameObject.FindWithTag("Enemies").GetComponentsInChildren<Transform>();
        for (var index = 1; index < tmp4.Length; index += 2)
        {
            output += "" +
                      tmp4[index].gameObject.activeSelf + ':' +
                      tmp4[index].position.x + ':' +
                      tmp4[index].position.y + ':' +
                      tmp4[index].position.z + ":" +
                      tmp4[index].gameObject.GetComponent<Killable>()._life +
                      "\n";
        }

        output += "\n";

        output += "" +
                  GoldAccount.instance.gold + ':' +
                  GoldAccount.instance.silver + ':' +
                  GoldAccount.instance.copper +
                  "\n";

        output += "\n";
        
        /*
         * MANQUE LES BUFFS
         */

        using (StreamWriter sw = new StreamWriter("SaveGame.txt"))
        {
            sw.Write(output);
        }
    }
}