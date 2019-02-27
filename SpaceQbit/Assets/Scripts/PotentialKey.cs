using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using UnityEngine;

public class PotentialKey : MonoBehaviour
{
    public KeyCode key;
    public Texture2D keyIcon;

    public PotentialKey Get()
    {
        return this;
    }
}
