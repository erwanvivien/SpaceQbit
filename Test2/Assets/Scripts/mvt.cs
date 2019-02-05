using System.Diagnostics;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class mvt : MonoBehaviour
{
    private bool dashable = true;

    private float lastTimePressed;
    private KeyCode lastKeyPressed;

    float lastTimeDash;
    
    public Camera mainCam;    
    public Terrain terrain;

    public float getLastTimeDash()
    {
        return lastTimeDash;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once  frame
    void Update()
    {
        float maxTimePressed = lastTimePressed + 0.2f;
        
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
                maxTimePressed > Time.time &&
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
                maxTimePressed > Time.time &&
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
                maxTimePressed > Time.time &&
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
                maxTimePressed > Time.time &&
                dashable)
            {
                transform.position += (Vector3.right * 0.5f);
                lastTimeDash = Time.time;
                dashable = false;
            }
                        
            lastKeyPressed = KeyCode.D;
            lastTimePressed = Time.time;         
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        }
    }
}
        