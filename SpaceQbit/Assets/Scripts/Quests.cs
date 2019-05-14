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

    [SerializeField] private string[] sentences;

    [SerializeField] private int award;

    public bool wannaRepeat;
    [NonSerialized] public bool done;
    

    private void Start()
    {
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Frame_Perso"))
            return;
        
        DialogueManager.instance.Enqueue(sentences);

        if (type.ToLower() == "validate")
        {
            QuestManager.instance.quests[questID].Done(); 
            QuestManager.instance.Reprint();
            done = true;
            gameObject.SetActive(wannaRepeat);
            return;
        }
        
        var gold = (award / 10000) % 100;
        var silver = (award % 10000) / 100;
        var copper = award % 100;

        if (award > 0)
        {
            var tmp = "[";
            if (gold != 0)
                tmp += " " + gold + " gold";
            if (silver != 0)
                tmp += " " + silver + " silver";
            if (copper != 0)
                tmp += " " + copper + " copper";
            tmp += " ]";
            
            DialogueManager.instance.Enqueue(tmp);
        }

        gameObject.SetActive(wannaRepeat);
        QuestManager.instance.Add(this);
    }

    public void Done()
    {
        done = true;
        GoldAccount.instance.AddGold(award);
    }
}