using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PotentialKey : MonoBehaviour
{
    public Texture2D keyIcon;
    public int KeyNumber;
    
    [NonSerialized] public KeyCode keyCode;
    [NonSerialized] public string keyName;

    private KeyBindArray _array;

    private void Start()
    {
        _array = GetComponentInParent<KeyBindArray>();
        
        
        KeyCode k = _array._keyBindings[KeyNumber];
        keyName = k.ToString();
        keyCode = k;
    }
}
