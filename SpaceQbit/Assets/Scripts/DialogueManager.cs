using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private string[] start;

    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject questPanel;

    public static DialogueManager instance;

    private Queue<string> queue = new Queue<string>();

    private void Start()
    {
        Enqueue(start);
        panel.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    public void Enqueue(string[] array)
    {
        foreach (string str in array)
        {
            queue.Enqueue(str);
        }
    }

    public void Enqueue(string s)
    {
        queue.Enqueue(s);
    }

    public void Update()
    {
        if (!panel.activeSelf && queue.Any())
        {
            panel.SetActive(true);
            questPanel.SetActive(false);
            panel.GetComponentInChildren<Text>().text = queue.Dequeue();
        }

        if (panel.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            if (!queue.Any())
            {
                panel.SetActive(false);
                questPanel.SetActive(true);
            }
            else
                panel.GetComponentInChildren<Text>().text = queue.Dequeue();
        }
    }
}