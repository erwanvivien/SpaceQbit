using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooOffset : MonoBehaviour
{
    private Vector3 _offset;
    private GameObject _instantiateFrom;

    public void SetOffset(Vector3 v)
    {
        _offset = v;
    }

    public void SetGameObj(GameObject g)
    {
        _instantiateFrom = g;
        transform.position = _instantiateFrom.transform.position + _offset;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = _instantiateFrom.transform.position + _offset;
    }
}