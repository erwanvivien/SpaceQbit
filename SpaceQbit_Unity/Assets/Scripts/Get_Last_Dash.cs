using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Last_Dash : MonoBehaviour
{
    private Mouvement_player otherScript;
    private float Dashed;
    private bool d;
    private float Cooldown_dash;

    void Start()
    {
        otherScript = GameObject.FindWithTag("Frame_Perso").GetComponent<Mouvement_player>();
        Cooldown_dash = otherScript.getCooldownDash();
    }

    void Update()
    {
        float lastDash = otherScript.getLastTimeDash();

        float cooldown = (lastDash + Cooldown_dash - Time.time) / Cooldown_dash;
        
        if (cooldown < 0 ||
            (Time.time <= 5 &&
            otherScript.getDashable()))
        {
            cooldown = 0;
        }

        transform.localScale = (new Vector3(cooldown, 1, 1));
    }
}
