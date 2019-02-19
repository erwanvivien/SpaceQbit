using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Serialization;

public class Search_Target : MonoBehaviour
{
    [SerializeField] private Material _mat;
    private Renderer _renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        if (_mat == null)
            _mat = GetComponent<Material>();
        
        _renderer = GetComponent<Renderer>();
        _renderer.material = _mat;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var q in GameObject.FindGameObjectsWithTag("Perso"))
        {
            Vector3 tmp = q.transform.position;
            Vector3 me = transform.position;

            float distance_squared = (tmp.x - me.x) * (tmp.x - me.x) + 
                                     (tmp.y - me.y) * (tmp.y - me.y) +
                                     (tmp.z - me.z) * (tmp.z - me.z);
            if (distance_squared < 5)
            {
                _renderer.material.color = Color.red;
            }
        }
    }
}
