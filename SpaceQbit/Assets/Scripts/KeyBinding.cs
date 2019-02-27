using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyBinding : MonoBehaviour
{
    public string keyBindName;
    public Texture2D keyIcon;
    public KeyCode currentBind;

    public void assignKey(PotentialKey key)
    {
        keyIcon = key.keyIcon;
        currentBind = key.key;
    }
}
