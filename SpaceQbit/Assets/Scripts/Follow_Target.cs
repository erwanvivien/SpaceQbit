using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Target : MonoBehaviour
{
    private GameObject target = null;

    public void SetTarget(GameObject trget)
    {
        target = trget;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    void Update()
    {
        if (target != null)
        {
            //SEEK TARGET
        }
    }
}
