using System.Net.Sockets;
using UnityEngine;

public class PCamera : BoltSingletonPrefab<PCamera>
{
    private Vector3 _b = Vector3.zero;

    // camera target
    GameObject _target;
    private Rigidbody tmp;

    private Vector3 _offset;

    [SerializeField] Transform cam;

    public Camera myCamera => transform.GetComponent<Camera>();

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void UpdateCamera()
    {
        Vector3 targetPosition = _target.transform.position + _offset;

        float a = tmp.velocity.x + tmp.velocity.y + tmp.velocity.z;

        cam.position =
            Vector3.SmoothDamp(cam.position, targetPosition, ref _b, 0.5f);
    }

    public void SetTarget(BoltEntity entity)
    {
        _target = entity.GetComponentsInChildren<BoxCollider>()[0].gameObject;

        _offset = new Vector3(1, 3, -3);
        cam.localEulerAngles = new Vector3(45, 0, 0);
        cam.localPosition = new Vector3(1, 3, -3);

        tmp = _target.GetComponentInChildren<Rigidbody>();
    }

    void LateUpdate()
    {
        UpdateCamera();
    }
}