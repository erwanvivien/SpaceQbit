using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsValues : MonoBehaviour
{
    public float _masterVol;
    public float  _musicVol;
    public float    _sfXVol;

    public void Master(float f)
    {
        _masterVol = f;
    }
    public void Music(float f)
    {
        _musicVol = f;
    }
    public void Sfx(float f)
    {
        _sfXVol = f;
    }
}
