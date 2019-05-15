using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeachChildren : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var q in GetComponentsInChildren<Transform>())
        {
            q.gameObject.tag = "Quest";
        }
    }
}
