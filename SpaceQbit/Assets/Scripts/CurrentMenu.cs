using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class CurrentMenu : MonoBehaviour
{
    public GameObject mainMenuCanvas;

    private Canvas _thisCanvas;
    private bool inMenu;
    
    public void Save()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void Start()
    {
        _thisCanvas = GetComponent<Canvas>();

        _thisCanvas.enabled = false;
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!_thisCanvas.enabled)
            {
                _thisCanvas.enabled = true;
            }
            else
            {
                if (mainMenuCanvas.activeSelf)
                {
                    _thisCanvas.enabled = false;
                }
            }
        }
    }

    public bool InMenu()
    {
        return DialogueManager.isDialoging || _thisCanvas.enabled;
    }
}
