using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class CurrentMenu : MonoBehaviour
{
    [NonSerialized] public Canvas Canv;
    [NonSerialized] public bool inMenu;

    public GameObject SaveBox;

    private Canvas _escapeCanvas;
    
    public void Save()
    {
        Vector3 pos = GameObject.FindWithTag("Frame_Perso").transform.position;
        
        using (StreamWriter sw = new StreamWriter("save.txt"))
        {
            sw.WriteLine(pos.x);
            sw.WriteLine(pos.y);
            sw.WriteLine(pos.z);
        }

        GameObject t = Instantiate(SaveBox);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SetCanvas(Canvas c)
    {
        if(Canv != null)
            Canv.enabled = false;
        Canv = c;
        Canv.enabled = true;
        inMenu = true;
    }

    public void ResetCanvas()
    {
        if (Canv != null)
            Canv.enabled = false;
        
        Canv = null;
        inMenu = false;
    }

    private void Start()
    {
        Canv = null;
        inMenu = false;

        _escapeCanvas = GetComponentsInChildren<Canvas>()[1];
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Canv == null)
            {
                SetCanvas(_escapeCanvas);
            }
            else if(Canv == _escapeCanvas)
            {
                ResetCanvas();
            }
        }
    }
}
