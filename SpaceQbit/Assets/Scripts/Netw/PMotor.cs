using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PMotor : MonoBehaviour
{
    public struct State
    {
        public Vector3 position;
        public Vector3 velocity;
    }

    State _state;
    CharacterController _cc;

    [SerializeField] float skinWidth = 0.08f;

    [SerializeField] float movingSpeed = 4f;

    [SerializeField] float maxVelocity = 32f;

    [SerializeField] Vector3 drag = new Vector3(1f, 0f, 1f);

    [SerializeField] LayerMask layerMask;

    Vector3 sphere
    {
        get
        {
            Vector3 p;

            p = transform.position;
            p.y += _cc.radius;
            p.y -= (skinWidth * 2);

            return p;
        }
    }

    Vector3 waist
    {
        get
        {
            Vector3 p;

            p = transform.position;
            p.y += _cc.height / 2f;

            return p;
        }
    }

    void Awake()
    {
        _cc = GetComponent<CharacterController>();
        _state = new State();
        _state.position = transform.localPosition;
    }

    public void SetState(Vector3 position, Vector3 velocity)
    {
        // assign new state
        _state.position = position;
        _state.velocity = velocity;

        // assign local position
        transform.localPosition = _state.position;
    }

    void Move(Vector3 velocity)
    {
        bool isGrounded = false;

        isGrounded = isGrounded || _cc.Move(velocity * BoltNetwork.FrameDeltaTime) == CollisionFlags.Below;
        isGrounded = isGrounded || _cc.isGrounded;
        isGrounded = isGrounded || Physics.CheckSphere(sphere, _cc.radius, layerMask);

        _state.position = transform.localPosition;
    }

    public State Move(bool forward, bool backward, bool left, bool right)
    {
        var moving = false;
        var movingDir = Vector3.zero;

        if (forward ^ backward)
        {
            movingDir.z = forward ? +1 : -1;
        }

        if (left ^ right)
        {
            movingDir.x = right ? +1 : -1;
        }

        //

        if (moving)
        {
            Move(movingDir * movingSpeed);
        }

        // clamp velocity
        _state.velocity = Vector3.ClampMagnitude(_state.velocity, maxVelocity);

        // apply drag
        _state.velocity.x = ApplyDrag(_state.velocity.x, drag.x);
        _state.velocity.y = ApplyDrag(_state.velocity.y, drag.y);
        _state.velocity.z = ApplyDrag(_state.velocity.z, drag.z);

        // apply movement
        Move(_state.velocity);

        // detect tunneling
        DetectTunneling();

        // update position
        _state.position = transform.localPosition;

        // done
        return _state;
    }

    float ApplyDrag(float value, float drag)
    {
        if (value < 0)
        {
            return Mathf.Min(value + (drag * BoltNetwork.FrameDeltaTime), 0f);
        }
        else if (value > 0)
        {
            return Mathf.Max(value - (drag * BoltNetwork.FrameDeltaTime), 0f);
        }

        return value;
    }

    void DetectTunneling()
    {
        RaycastHit hit;

        if (Physics.Raycast(waist, Vector3.down, out hit, _cc.height / 2, layerMask))
        {
            transform.position = hit.point;
        }
    }

    void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.DrawWireSphere(sphere, _cc.radius);

            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(waist, waist + new Vector3(0, -(_cc.height / 2f), 0));
        }
    }
}