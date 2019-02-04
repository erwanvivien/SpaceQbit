using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class mvt : MonoBehaviour
{
    private bool dashable = true;

    private float lastTimePressed;
    public KeyCode lastKeyPressed;

    private float lastTimeDash;
    
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision colli)
    {
        
    }

    // Update is called once  frame
    void Update()
    {
        if (lastTimeDash + 5 < Time.time)
        {
            dashable = true;
        }        
        
        
        float dt = Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Z))
        {            
            transform.position += (Vector3.forward * dt);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (lastKeyPressed == KeyCode.Z &&
                lastTimePressed < Time.time &&
                lastTimePressed + 1 > Time.time &&
                dashable)
            {
                transform.position += (Vector3.forward * 0.5f);
                lastTimeDash = Time.time;
                dashable = false;
            }
                        
            lastKeyPressed = KeyCode.Z;
            lastTimePressed = Time.time;         
        }
        
        
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += (Vector3.left * dt);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (lastKeyPressed == KeyCode.Q &&
                lastTimePressed < Time.time &&
                lastTimePressed + 1 > Time.time &&
                dashable)
            {
                transform.position += (Vector3.left * 0.5f);
                lastTimeDash = Time.time;
                dashable = false;
            }
                        
            lastKeyPressed = KeyCode.Q;
            lastTimePressed = Time.time;         
        }

        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.back* dt);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (lastKeyPressed == KeyCode.S &&
                lastTimePressed < Time.time &&
                lastTimePressed + 1 > Time.time &&
                dashable)
            {
                transform.position += (Vector3.back * 0.5f);
                lastTimeDash = Time.time;
                dashable = false;
            }
                        
            lastKeyPressed = KeyCode.S;
            lastTimePressed = Time.time;         
        }

        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * dt);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lastKeyPressed == KeyCode.D &&
                lastTimePressed < Time.time &&
                lastTimePressed + 1 > Time.time &&
                dashable)
            {
                transform.position += (Vector3.right * 0.5f);
                lastTimeDash = Time.time;
                dashable = false;
            }
                        
            lastKeyPressed = KeyCode.D;
            lastTimePressed = Time.time;         
        }

    }
}
        