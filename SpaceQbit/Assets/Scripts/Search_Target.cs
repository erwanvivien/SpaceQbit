using UnityEngine;

public class Search_Target : MonoBehaviour
{
    [SerializeField] private Material _mat = null;

    private Follow_Target _followTarget = null;
    
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
                                     (tmp.y - me.y) * (tmp.y - me.y) +
                                     (tmp.z - me.z) * (tmp.z - me.z);
            
            if (distanceSquared <= 5)
            {
                _followTarget.SetTarget(q);
                _renderer.material.color = Color.red;
            }

            if (distanceSquared >= 25)
            {
                _followTarget.SetTarget(null);
                _renderer.material.color = Color.green;
            }
        }
    }
}
