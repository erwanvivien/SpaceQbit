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

    public string path = "saveOptions.txt";

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(path)) return;

        using (var sr = new StreamReader(path))
        {
            string s;
            float tmp;
            bool hasBugged = false;
            if ((s = sr.ReadLine()) != null)
            {
                if (float.TryParse(s, out tmp))
                {
                    master.value = tmp;
                }
                else
                {
                    hasBugged = true;
                    master.value = 1;
                }
            }

            if ((s = sr.ReadLine()) != null)
            {
                if (float.TryParse(s, out tmp))
                {
                    music.value = tmp;
                }
                else
                {
                    hasBugged = true;
                    music.value = 1;
                }
            }

            if ((s = sr.ReadLine()) != null)
            {
                if (float.TryParse(s, out tmp))
                {
                    sFx.value = tmp;
                }
                else
                {
                    hasBugged = true;
                    sFx.value = 1;
                }
            }

            if (hasBugged)
            {
                File.Delete(path);
            }
        }
        
    }

    public void Save()
    {
        using (var sw = new StreamWriter(path))
        {
            sw.WriteLine(master.value);
            sw.WriteLine(music.value);
            sw.WriteLine(sFx.value);
        }
    }
}