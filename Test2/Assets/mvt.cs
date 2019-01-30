using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class mvt : MonoBehaviour
{
    private bool jump = false;
    private Rigidbody rigid;
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        terrain.tag = "Terrain";
    }

    private void OnCollisionEnter(Collision colli)
    {
        if (colli.gameObject.CompareTag(terrain.tag))
        {
            jump = false;
        }
    }

    // Update is called once  frame
    void Update()
    {
        float dt = Time.deltaTime * 2000;
        if (Input.GetKey(KeyCode.Z) && !jump)
        {
            rigid.AddForce(Vector3.forward * dt);
        }
        if (Input.GetKey(KeyCode.Q) && !jump)
        {
            rigid.AddForce(Vector3.left * dt);
        }
        if (Input.GetKey(KeyCode.S) && !jump)
        {
            rigid.AddForce(Vector3.back * dt);
        }
        if (Input.GetKey(KeyCode.D) && !jump)
        {
            rigid.AddForce(Vector3.right * dt);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            rigid.AddForce(Vector3.up * 700);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            jump = false;
        }
    }
}
        