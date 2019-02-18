using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenu : MonoBehaviour
{
    private bool _on;
    private Canvas _canv;
    private Canvas _canvCd;
    private Canvas _canvHp;

    public bool GetOn()
    {
        return _on;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _canv = GetComponent<Canvas>();
        _canvCd = GameObject.FindWithTag("Cooldown").GetComponent<Canvas>();
        _canvHp = GameObject.FindWithTag("HP").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        _canv.enabled = _on;
        _canvCd.enabled = !_on;
        _canvHp.enabled = !_on;
        
//        _canv.
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _on = !_on;
        }
    }
}
