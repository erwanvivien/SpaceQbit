using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.UIElements;
using Debug = UnityEngine.Debug;

public class mvt : MonoBehaviour
{
    private float accelerationStraighLine = 1.8f;

    
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
        float dt = Time.deltaTime;

        accelerationStraighLine = 1;
        if (Input.touchCount == 1)
        {
            accelerationStraighLine = 1.8f;
        }
        
        float maxTimePressed = lastTimePressed + 0.2f;
        if (lastTimeDash + 5 < Time.time && !dashable)
        {
            dashable = true;
        }        
        
        if (Input.GetKey(KeyCode.Z))
        {            
            transform.position += (Vector3.forward * dt) * accelerationStraighLine;
        }
     
        if (Input.GetKey(KeyCode.Q))
        {
            transform.position += (Vector3.left * dt) * accelerationStraighLine;
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += (Vector3.back* dt) * accelerationStraighLine;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += (Vector3.right * dt) * accelerationStraighLine;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || 
             Input.GetKeyDown(KeyCode.RightShift)) && 
             dashable)
        {
            transform.position += mainCam.velocity * 0.5f;
            lastTimeDash = Time.time;
            dashable = false;
        }
        
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
            Vector3 tmp = new Vector3(ray.direction.x, 0, ray.direction.z - 0.5f);
            transform.position += tmp * dt;
        }
    }
}
        