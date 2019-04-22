using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_to_Screen_Size : MonoBehaviour
{
    void Update()
    {
        int w = Screen.width / 2;
        int h = Screen.height / 2;

        float wScale = (float) w / 962;
        float hScale = (float) h / 455;

        transform.localScale = new Vector3(wScale, 1, hScale);
    }
}