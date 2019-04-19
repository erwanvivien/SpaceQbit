using UnityEngine;

public class Cam_Follow: Bolt.EntityBehaviour<ICameraState>
{
    private Vector3 _b = Vector3.zero;

    public GameObject Obj;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - Obj.transform.position;
    }
    
    void LateUpdate()
    {
        Vector3 targetPosition = Obj.transform.position;

        targetPosition += _offset;
        
        transform.position = 
            Vector3.SmoothDamp(transform.position, 
                targetPosition, 
                ref _b, 
                0.5f);
    }
}