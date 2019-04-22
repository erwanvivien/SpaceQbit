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

        _HPs.GetComponent<CooOffset>().SetOffset(new Vector3(0,
            GetComponent<CapsuleCollider>().height / 2 + 0.2f,
            0));
        _HPs.GetComponent<CooOffset>().SetGameObj(gameObject);

        _time = 0;
        _life -= dmg;

        RectTransform[] tmp = _HPs.GetComponentsInChildren<RectTransform>();

        tmp[2].localScale =
            new Vector3(_life / _lifeMax,
                1,
                1);
    }

    void Start()
    {
        tag = "Killable";
        _life = _lifeMax;
        _HPs = null;
        _delayShown = 5;
        _time = 0;
    }

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