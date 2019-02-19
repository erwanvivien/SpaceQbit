using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private int _life = 0;

    public bool Attack(int dmg)
    {
        _life -= dmg;
        return _life <= 0;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        tag = "Killable";
    }

    // Update is called once per frame
    void Update()
    {
        if (_life <= 0)
        {
            gameObject.SetActive(false);

            Destroy(this);
        }
    }
}
