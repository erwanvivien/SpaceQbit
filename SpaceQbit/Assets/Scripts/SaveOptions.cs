using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SaveOptions : MonoBehaviour
{
    public Slider master;
    public Slider music;
    public Slider sFx;


    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists("saveOptions.txt")) return;
        
        using (var sr = new StreamReader("saveOptions.txt"))
        {
            string s;
            if ((s = sr.ReadLine()) != null)
            {
                master.value = float.Parse(s);
            }
            if ((s = sr.ReadLine()) != null)
            {
                music.value = float.Parse(s);
            }
            if ((s = sr.ReadLine()) != null)
            {
                sFx.value = float.Parse(s);
            }
        }
    }

    public void Save()
    {
        using (var sw = new StreamWriter("saveOptions.txt"))
        {
            sw.WriteLine(master.value);
            sw.WriteLine(music.value);
            sw.WriteLine(sFx.value);
        }
    }
}