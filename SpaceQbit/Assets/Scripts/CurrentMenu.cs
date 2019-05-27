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
    public static bool _inMenu;
    public static bool _inVendor;

    public void SetVendor(bool t)
    {
        _inVendor = t;
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
        _inMenu = DialogueManager.isDialoging || _thisCanvas.enabled || _inVendor;
        if (!Input.GetKeyDown(KeyBind.keys["Menu"])) return;
        
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
