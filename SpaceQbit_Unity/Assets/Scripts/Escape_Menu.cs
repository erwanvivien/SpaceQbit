using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_Menu : MonoBehaviour
{
    private bool _on;
    private Canvas _canv;
    private Canvas _canv_CD;
    private Canvas _canv_HP;

    public bool getOn()
    {
        return _on;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _canv = GetComponent<Canvas>();
        _canv_CD = GameObject.FindWithTag("Cooldown").GetComponent<Canvas>();
        _canv_HP = GameObject.FindWithTag("HP").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        _canv.enabled = _on;
        _canv_CD.enabled = !_on;
        _canv_HP.enabled = !_on;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _on = !_on;
        }
    }
}
