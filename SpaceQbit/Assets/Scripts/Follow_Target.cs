using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Follow_Target : MonoBehaviour
{
    private GameObject _target;
    NavMeshAgent _nav;

    private Transform _tsfm;
    private Transform _tsfmPoule;
    private Vector3 _scalePouleSave;

    // Start is called before the first frame update    

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
        _nav = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _tsfm = GetComponent<Transform>();
        _tsfmPoule = GetComponentsInChildren<Transform>()[1];
        _scalePouleSave = _tsfmPoule.localScale;
    }

    void Update()
    {
        _tsfm.localEulerAngles = Vector3.zero;

        if (_target != null)
        {
            var position = _target.transform.position;
            var tmp = position;
            var me = transform.position;
            
            _tsfmPoule.localScale = new Vector3(_scalePouleSave.x * (tmp.x - me.x >= 0 ? 1 : -1), _scalePouleSave.y, _scalePouleSave.z);

            _nav.SetDestination(position);
        }
    }
}
