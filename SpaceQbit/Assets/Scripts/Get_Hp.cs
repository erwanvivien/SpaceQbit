using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Hp : MonoBehaviour
{
    [SerializeField] private float _maxLife = 100;
    
    private float _life;

    public void Damaged(float dmg)
    {
        _life -= dmg;
        _life = _life < 0 ? 0 : _life;
        
        transform.position.Scale(new Vector3(_life/_maxLife, 1, 1));
    }

    private void Start()
    {
        _life = _maxLife;
        transform.position.Scale(new Vector3(1, 1, 1));
    }
}
