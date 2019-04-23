using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTransparancy : MonoBehaviour
{
    private Renderer _renderer;
    private Color _color;

    // Start is called before the first frame update
    void Start()
    {
        Material m = GetComponent<Renderer>().material;
        m.color = new Color(m.color.r, m.color.g, m.color.b, 0);
        GetComponent<Renderer>().material = m;
    }

    public void Set(float nb)
    {
        Material m = GetComponent<Renderer>().material;
        m.color = new Color(m.color.r, m.color.g, m.color.b, nb);
        GetComponent<Renderer>().material = m;
    }
    
    
}
