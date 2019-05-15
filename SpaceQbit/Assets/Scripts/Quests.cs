using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Quests : MonoBehaviour
{
    public int questID;

    public string type;
    public string who;
    public int howMany;

    public string[] sentences;

    public int award;

    public bool wannaRepeat;
    [NonSerialized] public bool done;
    [NonSerialized] public bool pickedUp;


    private void Start()
    {
        QuestManager.allQuests.Add(this);

        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Frame_Perso"))
            return;

        Activate();
    }

    public void Activate(bool auto = false)
    {
        if (QuestManager.instance.idDone.Contains(questID))
            return;

        if (!auto)
        {
            DialogueManager.instance.Enqueue(sentences);
            
            var gold = (award / 10000) % 100;
            var silver = (award % 10000) / 100;
            var copper = award % 100;

            if (award > 0)
            {
                var tmp = "[";
                if (gold != 0)
                    tmp += " " + gold + " black market coin";
                if (silver != 0)
                    tmp += " " + silver + " gold";
                if (copper != 0)
                    tmp += " " + copper + " silver";
                tmp += " ]";

                DialogueManager.instance.Enqueue(tmp);
            }
        }
        pickedUp = true;

        if (type.ToLower() == "validate")
        {
            QuestManager.instance.questsToDo[questID].Done();
            QuestManager.instance.Reprint();
            done = true;
            gameObject.SetActive(wannaRepeat);
            return;
        }


        gameObject.SetActive(wannaRepeat);
        QuestManager.instance.Add(this);
    }

    public void Done()
    {
        DoneLoad();
        GoldAccount.instance.AddGold(award);
    }

    public void DoneLoad()
    {
        done = true;
        QuestManager.instance.idDone.Add(questID);
    }
}