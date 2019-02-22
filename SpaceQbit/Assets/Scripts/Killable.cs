using System.Collections;
using System.Collections.Generic;
using Bolt;
using UnityEngine;
using UnityEngine.Serialization;

public class Killable : MonoBehaviour
{
    [SerializeField] private float _lifeMax = 0;
    [SerializeField] private GameObject _hpBar = null;

    private GameObject _HPs;
    private float _time;

    private float _delayShown;

private float _life;

    public void Attack(int dmg)
    {
        if (_HPs == null)
        {
            _HPs = Instantiate(_hpBar);
        }
        
        _HPs.SetActive(true);
        _time = 0;

        _life -= dmg;
        Debug.Log(_life);

        Vector3 pos = GetComponent<Transform>().position;
        
        _HPs.GetComponent<Transform>().position = 
            new Vector3(pos.x, 
            GetComponent<CapsuleCollider>().height / 2 + 0.5f,
            pos.z);
        
        Transform[] tmp = _HPs.GetComponentsInChildren<RectTransform>();
        
        tmp[2].localScale = 
            new Vector3(_life/_lifeMax,
                1,
                1);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        tag = "Killable";
        _life = _lifeMax;
        _HPs = null;
        _delayShown = 5;
        _time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_time > _delayShown && _HPs != null)
        {
            _HPs.SetActive(false);
        }
        
        if (_life <= 0)
        {
            gameObject.SetActive(false);
            Destroy(_HPs);
            Destroy(gameObject);
        }

        _time += Time.deltaTime;
    }
}
