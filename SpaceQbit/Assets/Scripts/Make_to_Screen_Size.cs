using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_to_Screen_Size : MonoBehaviour
{
    void Update()
    {
        var w = Screen.width / 2;
        var h = Screen.height / 2;

        var wScale = (float) w / 962;
        var hScale = (float) h / 455;

        transform.localScale = new Vector3(wScale, 1, hScale);
    }
}
