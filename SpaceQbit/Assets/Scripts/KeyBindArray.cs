using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindArray : MonoBehaviour
{
    private KeyCode[] _keyBindings = new KeyCode[50];

    public KeyCode[] Array()
    {
        return _keyBindings;
    }
    
    public KeyCode keyBind(int x)
    {
        if(x >= 0 && x < _keyBindings.Length)
            return _keyBindings[x];
        
        return KeyCode.None;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _keyBindings[00] = KeyCode.RightArrow;
        _keyBindings[01] = KeyCode.UpArrow;
        _keyBindings[02] = KeyCode.LeftArrow;
        _keyBindings[03] = KeyCode.DownArrow;
        _keyBindings[04] = KeyCode.D;
        _keyBindings[05] = KeyCode.Z;
        _keyBindings[06] = KeyCode.Q;
        _keyBindings[07] = KeyCode.S;
        _keyBindings[08] = KeyCode.Space;
        _keyBindings[09] = KeyCode.R;
        _keyBindings[10] = KeyCode.LeftShift;
//        _keyBindings[11] = KeyCode.
//        _keyBindings[12] = KeyCode.
//        _keyBindings[13] = KeyCode.
//        _keyBindings[14] = KeyCode.
//        _keyBindings[15] = KeyCode.
//        _keyBindings[16] = KeyCode.
//        _keyBindings[17] = KeyCode.
//        _keyBindings[18] = KeyCode.
//        _keyBindings[19] = KeyCode.
//        _keyBindings[20] = KeyCode.
//        _keyBindings[21] = KeyCode.
//        _keyBindings[22] = KeyCode.
//        _keyBindings[23] = KeyCode.
//        _keyBindings[24] = KeyCode.
//        _keyBindings[25] = KeyCode.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
