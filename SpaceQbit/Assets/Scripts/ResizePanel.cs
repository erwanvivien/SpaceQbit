using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Serialization;

public class ResizePanel : MonoBehaviour
{
    public float posX;
    public float width;
    public float posY;
    [FormerlySerializedAs("removeBottom")] public float height;

    private RectTransform panel;

    // Start is called before the first frame update
    void Start()
    {
        panel = GetComponent<RectTransform>();
        
        panel.anchorMax = new Vector2(0, 1);
        panel.anchorMin = new Vector2(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        var sizeDelta = new Vector2((width / 100) * Screen.width,
            (height / 100) * Screen.height);
        
        panel.sizeDelta = sizeDelta;
        
        var anchoredPosition = new Vector2(sizeDelta.x, -sizeDelta.y) / 2 + 
                               new Vector2((posX / 100)*Screen.width,-(posY /100) * Screen.height);
        
        panel.anchoredPosition = anchoredPosition;
    }
}