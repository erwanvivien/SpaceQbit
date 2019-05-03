using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    private GameObject _audio;

    private void Start()
    {
        _audio = GameObject.FindWithTag("Audio");
    }


    public void LoadByIndex(int sceneindex)
    {
        if (sceneindex != 0)
        {
            float volume = _audio.GetComponent<AudioSource>().volume;
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
