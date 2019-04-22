using UnityEngine;

public class Search_Target : MonoBehaviour
{
    [SerializeField] private Material _mat;
    [SerializeField] private float _damage;

    private float _time;

    private Follow_Target _followTarget;

    private Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        if (_mat == null)
            _mat = GetComponent<Material>();

        if (_followTarget == null)
            _followTarget = GetComponent<Follow_Target>();

        _renderer = GetComponent<Renderer>();
        _renderer.material = _mat;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var q in GameObject.FindGameObjectsWithTag("Perso"))
        {
            Vector3 tmp = q.transform.position;
            Vector3 me = transform.position;

            float distanceSquared = (tmp.x - me.x) * (tmp.x - me.x) +
                                    (tmp.z - me.z) * (tmp.z - me.z);

//            Debug.Log(distanceSquared);

            if (distanceSquared <= 2)
            {
                _followTarget.SetTarget(null);
                if (_time <= 0)
                {
                    Debug.Log("Hit.");
                    GameObject.FindWithTag("HealthBar").GetComponent<Get_Hp>().Damaged(_damage);
                    _time = 2;
                }
            }
            else if (distanceSquared <= 5)
            {
                _followTarget.SetTarget(q);
                _renderer.material.color = Color.red;
            }
            else if (distanceSquared >= 15)
            {
                _followTarget.SetTarget(null);
                _renderer.material.color = Color.green;
            }
        }

        _time -= Time.deltaTime;
        _time = _time < 0 ? 0 : _time;
    }
}