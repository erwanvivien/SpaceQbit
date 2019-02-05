using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLastDash : MonoBehaviour
{
    private mvt otherScript;
    
    // Start is called before the first frame update
    void Start()
    {
        otherScript = GameObject.FindWithTag("Frame").GetComponent<mvt>();
    }

    // Update is called once per frame
    void Update()
    {
        float a = (otherScript.getLastTimeDash() + 5 - Time.time) / 5;
        
        transform.position.Scale(new Vector3(0, 0.1f, 1));

        if (otherScript.getLastTimeDash() < Time.time &&
            otherScript.getLastTimeDash() + 5 > Time.time)
        {
            transform.position.Scale(new Vector3(0.8f * a, 0.1f, 1));
        }
    }
}
