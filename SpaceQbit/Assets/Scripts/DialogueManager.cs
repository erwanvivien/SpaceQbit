using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string[] start;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject[] questPanels;

    public static DialogueManager instance;

    public Queue<string> queue = new Queue<string>();
    private Text _text;

    public static bool isDialoging;

    private void Start()
    {
        _text = panel.GetComponentInChildren<Text>();
        Enqueue(start);
        panel.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    public void Enqueue(string[] array)
    {
        foreach (var str in array)
        {
            Enqueue(str);
        }
    }

    public void Enqueue(string s)
    {
        queue.Enqueue(s);
        isDialoging = true;
    }
    
    

    public void Update()
    {
        if (!panel.activeSelf && queue.Any())
        {
            panel.SetActive(true);
            foreach (var q in questPanels)
            {
                q.SetActive(false);
            }
            _text.text = queue.Dequeue();
        }

        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            if (!queue.Any())
            {
                isDialoging = false;
                panel.SetActive(false);
                foreach (var q in questPanels)
                {
                    q.SetActive(true);
                }
            }
            else
                _text.text = queue.Dequeue();
        }
    }
}