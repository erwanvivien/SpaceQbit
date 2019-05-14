using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private GameObject[] panel;
    private Text[] _textTitle;
    private Text[] _textText;

    [NonSerialized] public bool NeedToReprint;

    public static QuestManager instance;

    public Dictionary<int, Quests> quests = new Dictionary<int, Quests>();

    private void Start()
    {
        _textText = new Text[panel.Length];
        _textTitle = new Text[panel.Length];
        var i = 0;

        foreach (var q in panel)
        {
            _textTitle[i] = q.GetComponentsInChildren<Text>()[0];
            _textText[i] = q.GetComponentsInChildren<Text>()[1];
            i++;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void Add(Quests q)
    {
        quests.Add(q.questID, q);

        NeedToReprint = true;
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

        NeedToReprint = t;
    }

    public void Reprint()
    {
        for (var j = 0; j < _textText.Length; j++)
        {
            panel[j].SetActive(false);
        }

        if (DialogueManager.isDialoging)
        {
            NeedToReprint = true;

            return;
        }

        var x = quests.Values.ToList();
        for (var i = 0; i < x.Count; i++)
        {
            if (x[i].done)
            {
                quests.Remove(x[i].questID);
                x.RemoveAt(i);
                i--;
                continue;
            }

            if (i >= 3) break;

            panel[i].SetActive(true);

            var tmp = x[i].type.ToLower();
            switch (tmp)
            {
                case "kill":
                    _textTitle[i].color = Color.red;
                    _textTitle[i].text = "Kill";
                    
                    _textText[i].color = new Color(0.5f, 0, 0);
                    _textText[i].text = "\n" + x[i].howMany + " " + x[i].who;
                    break;
                case "speakto":
                    _textTitle[i].color = new Color(0, 0.8f, 0.8f);
                    _textTitle[i].text = "Speak to :";
                    
                    _textText[i].color = Color.cyan;
                    _textText[i].text = "\n" + x[i].who;
                    break;
                case "goto":
                    _textTitle[i].color = Color.yellow;
                    _textTitle[i].text = "Go to :";
                    _textText[i].color = new Color(0.8f, 0.5f, 0);
                    _textText[i].text = "\n" + x[i].who;
                    break;
                default:
                    break;
            }
        }

        if (quests.Values.Count > 3)
        {
            panel[3].SetActive(true);
            _textTitle[3].text = "and more...";
        }
    }

    private void Update()
    {
        if (NeedToReprint)
        {
            NeedToReprint = false;
            Reprint();
        }
    }
}