﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Last_Dash : MonoBehaviour
{
    private Mouvement_player otherScript;
    private float Dashed;
    private bool d;
    
    // Start is called before the first frame update
    void Start()
    {
        otherScript = GameObject.FindWithTag("Frame").GetComponent<Mouvement_player>();
    }

    // Update is called once per frame
    // otherScript.getLastTimeDash()
    void Update()
    {
        float lastDash = otherScript.getLastTimeDash();

        float cooldown = (lastDash + 5 - Time.time) / 5;
        if (cooldown < 0 || (Time.time <= 5 && otherScript.getDashable())) cooldown = 0;

        transform.localScale = (new Vector3(cooldown, 1, 1));
    }
}