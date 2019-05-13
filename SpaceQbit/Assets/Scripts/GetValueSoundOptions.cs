using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class GetValueSoundOptions : MonoBehaviour
{
    public string SfxOrMusic;
    private OptionsValues _optionsValues;

    private AudioSource _source;

    private void Start()
    {
        _optionsValues = GameObject.FindWithTag("Menu").GetComponent<OptionsValues>();
        _source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SfxOrMusic.ToLower() == "music")
        {
            _source.volume = _optionsValues._masterVol * _optionsValues._musicVol;
        }
        else if (SfxOrMusic.ToLower() == "sfx")
        {
            _source.volume = _optionsValues._masterVol * _optionsValues._sfXVol;
        }
        else
        {
            _source.volume = _optionsValues._masterVol;
        }
    }
}
