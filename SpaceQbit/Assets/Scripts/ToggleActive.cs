using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleActive : MonoBehaviour
{
    private bool _isHidden;
    private Canvas _canv;

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _canv.enabled = false;
        _isHidden = true;
    }
    public void Show()
    {
        _canv.enabled = true;
        _isHidden = false;
    }
    public void Toggle()
    {
        _canv.enabled = !_canv.enabled;
        _isHidden = !_isHidden;
    }

    void Start()
    {
        _canv = GetComponent<Canvas>();
    }
}
