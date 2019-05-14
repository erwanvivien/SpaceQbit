using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Text _text;

    public static QuestManager instance;

    private Dictionary<int, Quests> quests = new Dictionary<int, Quests>();

    private void Start()
    {
        panel.SetActive(false);
        _text = panel.GetComponentInChildren<Text>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Add(Quests q)
    {
        quests.Add(q.questID, q);

        if (quests.Keys.Count <= 4)
        {
            _text.text +=
                q.type + "\n" + q.howMany + " " + q.who + "\n\n";
        }
        else
        {
            _text.text += "and more";
        }
    }

    public void UpdateKillingQuests(string mobTag)
    {
        bool t = false;
        foreach (var q in quests.Values)
        {
            if (!string.Equals(q.who, mobTag, StringComparison.OrdinalIgnoreCase)) continue;
            
            t = true;
            q.howMany--;

            if (q.howMany == 0)
            {
                q.Done();
            }
        }

        if (t)
        {
            Reprint();
        }
    }
    
    public void UpdateSpeaktoQuests(string npcTag)
    {
        var t = false;
        npcTag = npcTag.ToLower();
        
        foreach (var q in quests.Values)
        {
            if (q.who.ToLower() == npcTag)
            {
                t = true;
                q.Done();
            }
        }

        if (t)
        {
            Reprint();
        }
    }

    private void Reprint()
    {
        var x = quests.Values.ToArray();
        _text.text = "";
        for (var i = 0; i < (x.Length >= 4 ? 4 : x.Length); i++)
        {
            if (x[i].done) continue;
            
            switch (x[i].type.ToLower())
            {
                case "kill":
                    _text.text +=
                        x[i].type + "\n" + x[i].howMany + " " + x[i].who + "\n\n";
                    break;
                default:
                    _text.text +=
                        x[i].type + "\n" + x[i].who + "\n\n";
                    break;
            }
        }
    }
}