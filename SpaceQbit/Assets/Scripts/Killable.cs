using System;
using UnityEngine;
using Random = System.Random;

public class Killable : MonoBehaviour
{
    [SerializeField] private float lifeMax = 0;
    [SerializeField] private GameObject hpBar = null;

    [SerializeField] private string mobTag;

    [SerializeField] private int MinGold;
    [SerializeField] private int MaxGold;

    private GameObject _hPs;
    private float _time;

    private float _delayShown;
    private Random _rdm = new Random();
    public float life;

    public void Attack(int dmg)
    {
        if (_hPs == null)
        {
            _hPs = Instantiate(hpBar);
        }

        _hPs.SetActive(true);

        _hPs.GetComponent<CooOffset>().SetOffset(new Vector3(0,
            GetComponent<BoxCollider>().size.x / 2 + 0.2f,
            0));
        _hPs.GetComponent<CooOffset>().SetGameObj(gameObject);

        _time = 0;
        life -= dmg;

        var tmp = _hPs.GetComponentsInChildren<RectTransform>();

        tmp[2].localScale =
            new Vector3(life / lifeMax,
                1,
                1);
    }

    void Start()
    {
        tag = "Killable";
        life = lifeMax;
        _hPs = null;
        _delayShown = 5;
        _time = 0;
    }

    void Update()
    {
        if (_time > _delayShown && _hPs != null)
        {
            _hPs.SetActive(false);
        }

        if (life <= 0)
        {
            QuestManager.instance.UpdateKillingQuests(mobTag);
            GoldAccount.instance.AddGold(_rdm.Next(MinGold, MaxGold));

            gameObject.SetActive(false);
            Destroy(_hPs);
            //Destroy(gameObject);
        }

        _time += Time.deltaTime;
    }
}