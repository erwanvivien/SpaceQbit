﻿using System;
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

    public bool done;

    private void Start()
    {
        done = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Frame_Perso"))
            return;

        DialogueManager.instance.Enqueue(sentences);

        int gold = (award / 10000) % 100;
        int silver = (award % 10000) / 100;
        int copper = award % 100;

        if (award > 0)
        {
            string tmp = "[";
            if (gold != 0)
                tmp += " " + gold + " gold";
            if (silver != 0)
                tmp += " " + silver + " silver";
            if (copper != 0)
                tmp += " " + copper + " copper";
            tmp += " ]";
            
            DialogueManager.instance.Enqueue(tmp);
        }

        gameObject.SetActive(false);
        QuestManager.instance.Add(this);
    }

    public void Done()
    {
        done = true;
        GoldAccount.instance.AddGold(award);
    }
}