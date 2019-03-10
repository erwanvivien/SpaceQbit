using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Follow_Target : MonoBehaviour
{
    private GameObject target = null;
    NavMeshAgent nav;
    Transform player;

    public void SetTarget(GameObject trget)
    {
        target = trget;
    }

    public GameObject GetTarget()
    {
        return target;
    }
    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Perso").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (target != null)
        {
            nav.SetDestination(player.position);
        }
    }
}
