using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private string[] sentences;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Frame_Perso"))
            return;
        
        DialogueManager.instance.Enqueue(sentences);
        gameObject.SetActive(false);
    }
}

