using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DisapearAfter : MonoBehaviour
{
    [SerializeField] private float time;

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            gameObject.SetActive(false);
        }

        time -= Time.deltaTime;
    }
}
