using TMPro;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.Serialization;

public class Search_Target : MonoBehaviour
{
    [SerializeField] private float damage = 5;

    public int minRange = 2;
    public int midRange = 10;
    public int maxRange = 20;

    private float _time;
    private bool _isAttacking;

    private string _s;

    private Follow_Target _followTarget;
    private GameObject _target;

    private Vector3 scale_poule_save;
    private Transform scale_poule;
    
    [SerializeField] private Animator anm;
        
    // Start is called before the first frame update
    void Start()
    {
        scale_poule = GetComponentInChildren<Transform>();
        scale_poule_save = scale_poule.localScale;
        
        if (anm == null)
            anm = gameObject.GetComponentInChildren<Animator>();

        if (_followTarget == null)
            _followTarget = GetComponent<Follow_Target>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
        _s = _time >= 1.5f ? "poule_attack" : "poule_rest";
        
        foreach (var q in GameObject.FindGameObjectsWithTag("Perso")) // SEEKS FOR EVERY GAMEOBJECT WITH TAG "PERSO" AND TESTS IF THEY ARE CLOSE ENOUGH
        {
            Vector3 tmp = q.transform.position;
            Vector3 me = transform.position;


            float distanceSquared = (tmp.x - me.x) * (tmp.x - me.x) + 
                                    (tmp.z - me.z) * (tmp.z - me.z);
            
            if (distanceSquared <= minRange)
            {
                _isAttacking = true;
                if (_time <= 0)
                {
                    _s = "poule_attack";
//                    var b = _target;
//                    var c = b.GetComponentsInParent<Transform>()[1];
//                    var d = c.gameObject;
//                    var e = d.GetComponentsInParent<Transform>()[1];
//                    var f = e.gameObject;
//                    var g = f.GetComponentsInChildren<Get_Hp>()[0];
//                    g.Damaged(_damage);
                    
                    _target.GetComponentsInParent<Transform>()[1].gameObject.GetComponentsInParent<Transform>()[1].gameObject.GetComponentsInChildren<Get_Hp>()[0].Damaged(damage);
                    // GOES THROUGH ARCHITECTURE OF THE GAMEOBJECTs AND FIND THE HEALTH BAR

                    _time = 2;
                }

                _followTarget.SetTarget(null);
            }
            else
            {
                _isAttacking = false;
            }
            if (distanceSquared <= midRange && !_isAttacking)
            {
                _s = _time >= 1.5f ? "poule_attack" : "poule_run";
                _target = q;
                _followTarget.SetTarget(q);
                break;
            }
            if (distanceSquared >= maxRange && _target != null)
            {
                _target = null;
                _followTarget.SetTarget(null); // MEANS IT'S TOO FAR
            }

        }

        anm.Play(_s);

        _time -= Time.deltaTime;
        _time = _time < 0 ? 0 : _time;
    }
}
