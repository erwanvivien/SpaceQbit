using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private Text _textTitle;
    private Text _textText;

    public static QuestManager instance;

    public Dictionary<int, Quests> quests = new Dictionary<int, Quests>();

    private void Start()
    {
        panel.SetActive(false);
        _textTitle = panel.GetComponentsInChildren<Text>()[0];
        _textText = panel.GetComponentsInChildren<Text>()[1];
    }

    private void Awake()
    {
        instance = this;
    }

    public void Add(Quests q)
    {
        quests.Add(q.questID, q);

        Reprint();
    }

    public void UpdateKillingQuests(string mobTag)
    {
        var t = false;
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

    public void Reprint()
    {
        var x = quests.Values.ToList();
        _textText.text = "";
        _textTitle.text = "";
        var i = 0;
        
        for (; i < (x.Count > 3 ? 3 : x.Count); i++)
        {
            if (x[i].done)
            {
                quests.Remove(x[i].questID);
                x.RemoveAt(i);
                i--;
                continue;
            }

            var tmp = x[i].type.ToLower();
            switch (tmp)
            {
                case "kill":
                    _textTitle.text += "Kill\n\n\n";
                    _textText.text += "\n" + x[i].howMany + " " + x[i].who + "\n\n";
                    break;
                case "speakto":
                    _textTitle.text += "Speak to :\n\n\n";
                    _textText.text += "\n" + x[i].who + "\n\n";
                    break;
                case "goto":
                    _textTitle.text += "Go to :\n\n\n";
                    _textText.text += "\n" + x[i].who + "\n\n";
                    break;
            }
        }

        if (quests.Values.Count > 3)
        {
            _textText.text += "and more...";
        }
    }
}