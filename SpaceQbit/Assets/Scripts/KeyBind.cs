using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBind : MonoBehaviour
{
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text forward, backward, left, right, boost, dash, dialogue, menu;

    private GameObject currentKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

    public static Dictionary<string, KeyCode> GetKeys()
    {
        return keys;
    }
    void Start()
    {
        keys.Add("Forward", KeyCode.W);
        keys.Add("Backward", KeyCode.S);
        keys.Add("Left", KeyCode.A);
        keys.Add("Right", KeyCode.D);
        keys.Add("Boost", KeyCode.R);
        keys.Add("Dash", KeyCode.LeftShift);
        keys.Add("Dialogue", KeyCode.Space);
        keys.Add("Menu", KeyCode.Escape);

        forward.text = keys["Forward"].ToString();
        backward.text = keys["Backward"].ToString();
        left.text = keys["Left"].ToString();
        right.text = keys["Right"].ToString();
        boost.text = keys["Boost"].ToString();
        dash.text = keys["Dash"].ToString();
        dialogue.text = keys["Dialogue"].ToString();
        menu.text = keys["Menu"].ToString();
    }

    void Update()
    {
        
    }

    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }
        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;
    }
}
