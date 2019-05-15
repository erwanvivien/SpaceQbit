using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    private GameObject _audio;
    public bool wannaLoadSave;

    private void Start()
    {
        _audio = GameObject.FindWithTag("Audio");
    }


    public void LoadByIndex(int sceneindex)
    {
        LoadOptions.UsingSave = wannaLoadSave;
        
        if (sceneindex != 0)
        {
            var volume = _audio.GetComponent<AudioSource>().volume;
            float time = 5;
            
            while (time >= 0)
            {
                time -= Time.deltaTime;
                
                
                //_cube.GetComponent<SetTransparancy>().Set(1 - time / 2f);
                _audio.GetComponent<AudioSource>().volume = time / 2f * volume;
            }
        }
        
        SceneManager.LoadScene(sceneindex);
    }
}
