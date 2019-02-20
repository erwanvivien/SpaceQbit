using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] private int _life = 0;
    

    public void Attack(int dmg)
    {
        _life -= dmg;
        
//        GameObject newOne = Instantiate()
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
        }
    }
}
