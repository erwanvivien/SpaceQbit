using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow_Target : MonoBehaviour
{
    private GameObject _target;
    NavMeshAgent _nav;
    Transform _player;

    public void SetTarget(GameObject tgt)
    {
        _target = tgt;
        if (tgt == null)
        {
            _nav.SetDestination(GetComponent<Transform>().position);
        }
    }

    public GameObject GetTarget()
    {
        return _target;
    }
    
    void Awake()
    {
        _player = GameObject.FindWithTag("Perso1").transform;
        _nav = GetComponent<NavMeshAgent>();
    }
    
    void Update()
    {
        if (_target != null)
        {
            _nav.SetDestination(_player.position);
        }
    }
}
