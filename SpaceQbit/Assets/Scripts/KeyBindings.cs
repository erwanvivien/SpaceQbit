using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBindings : MonoBehaviour
{
    public KeyBindingManager
    
    public KeyCode[] keyMap = new KeyCode[50];
    
    
    void Start()
    {
        keyMap[0]  = KeyCode.RightArrow;
        keyMap[1]  = KeyCode.UpArrow;
        keyMap[2]  = KeyCode.LeftArrow;
        keyMap[3]  = KeyCode.DownArrow;
        keyMap[4]  = KeyCode.D;
        keyMap[5]  = KeyCode.Z;
        keyMap[6]  = KeyCode.Q;
        keyMap[7]  = KeyCode.S;
        keyMap[8]  = KeyCode.Space;
        keyMap[9]  = KeyCode.Escape;
        keyMap[10] = KeyCode.LeftShift;
        keyMap[11] = KeyCode.R;
    }
}
