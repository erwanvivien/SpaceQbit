using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Make_to_Screen_Size : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int w = Screen.width / 2;
        int h = Screen.height / 2;

        float w_scale = (float) w / 962;
        float h_scale = (float) h / 455;

        transform.localScale = new Vector3(w_scale, 1, h_scale);

    }
}
