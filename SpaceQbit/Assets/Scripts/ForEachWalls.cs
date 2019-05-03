using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForEachWalls : MonoBehaviour
{
    public Material mat;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (var q in GetComponentsInChildren<Renderer>())
        {
            if(q.gameObject.CompareTag("Mur"))
                q.material = mat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
