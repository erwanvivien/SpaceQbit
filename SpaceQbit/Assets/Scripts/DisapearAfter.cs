using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DisapearAfter : MonoBehaviour
{
    [SerializeField] private float _tmp;
    private float _time;

    void Start()
    {
        _time = _tmp;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time <= 0)
        {
            Destroy(gameObject);
        }

        _time -= Time.deltaTime;
    }
}
