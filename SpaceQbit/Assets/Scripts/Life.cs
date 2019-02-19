using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int _life = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Killable";
    }

    // Update is called once per frame
    void Update()
    {
        _life--;
    }
}
