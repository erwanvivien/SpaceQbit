using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour
{
    public EventSystem eventSystem;
    public GameObject selectedObject;

    private bool _buttonSelected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Vertical") != 0 && _buttonSelected == false)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            _buttonSelected = true;
        }
    }

    private void OnMouseOver()
    {
        GetComponent<AudioSource>().Play();
    }

    private void OnDisable()
    {
        _buttonSelected = false;
    }
}
