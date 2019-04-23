using Bolt;
using UnityEngine;

public class PController : Bolt.EntityBehaviour<IPlayerState>
{
    /*
    const float MOUSE_SENSITIVITY = 2f;

    bool _forward;
    bool _backward;
    bool _left;
    bool _right;
    bool _jump;

    float _yaw;
    float _pitch;

    PMotor _motor;

    void Awake()
    {
        _motor = GetComponent<PMotor>();
    }

    public override void Attached()
    {
        state.SetTransforms(state.transform, transform);
    }

    void PollKeys(bool mouse)
    {
        _forward = Input.GetKey(KeyCode.Z);
        _backward = Input.GetKey(KeyCode.S);
        _left = Input.GetKey(KeyCode.Q);
        _right = Input.GetKey(KeyCode.D);
        _jump = Input.GetKeyDown(KeyCode.Space);

        if (mouse)
        {
            _yaw += (Input.GetAxisRaw("Mouse X") * MOUSE_SENSITIVITY);
            _yaw %= 360f;

            _pitch += (-Input.GetAxisRaw("Mouse Y") * MOUSE_SENSITIVITY);
            _pitch = Mathf.Clamp(_pitch, -85f, +85f);
        }
    }

    void Update()
    {
        PollKeys(true);
    }

    public override void SimulateController()
    {
        PollKeys(false);

        IPlayerCommandInput input = PlayerCommand.Create();

        input.Forward = _forward;
        input.Backward = _backward;
        input.Left = _left;
        input.Right = _right;

        entity.QueueInput(input);
    }

    public override void ExecuteCommand(Command command, bool resetState)
    {
        PlayerCommand cmd = (PlayerCommand) command;

        if (resetState)
        {
            _motor.SetState(cmd.Result.Position, cmd.Result.Velocity, true, 0);
        }
        else
        {
            PMotor.State motorState = _motor.Move(cmd.Input.Forward, cmd.Input.Backward, cmd.Input.Left,
                cmd.Input.Right, false, 0f);

            // copy the motor state to the commands result (this gets sent back to the client)
            cmd.Result.Position = motorState.position;
            cmd.Result.Velocity = motorState.velocity;
        }
    }*/
    const float MOUSE_SENSITIVITY = 2f;

    bool _forward;
    bool _backward;
    bool _left;
    bool _right;
    bool _jump;

    float _yaw;
    float _pitch;

    PMotor _motor;

    void Awake()
    {
        _motor = GetComponent<PMotor>();
    }

    public override void Attached()
    {
        state.SetTransforms(state.transform, transform);
    }

    void PollKeys(bool mouse)
    {
        _forward = Input.GetKey(KeyCode.W);
        _backward = Input.GetKey(KeyCode.S);
        _left = Input.GetKey(KeyCode.A);
        _right = Input.GetKey(KeyCode.D);
        _jump = Input.GetKeyDown(KeyCode.Space);

        if (mouse)
        {
            _yaw += (Input.GetAxisRaw("Mouse X") * MOUSE_SENSITIVITY);
            _yaw %= 360f;

            _pitch += (-Input.GetAxisRaw("Mouse Y") * MOUSE_SENSITIVITY);
            _pitch = Mathf.Clamp(_pitch, -85f, +85f);
        }
    }

    void Update()
    {
        PollKeys(false);
    }

    public override void SimulateController()
    {
        PollKeys(false);

        IPlayerCommandInput input = PlayerCommand.Create();

        input.Forward = _forward;
        input.Backward = _backward;
        input.Left = _left;
        input.Right = _right;
        input.Jump = _jump;
        input.Yaw = _yaw;
        input.Pitch = _pitch;

        entity.QueueInput(input);
    }

    public override void ExecuteCommand(Command command, bool resetState)
    {
        PlayerCommand cmd = (PlayerCommand)command;

        if (resetState)
        {
            _motor.SetState(cmd.Result.Position, cmd.Result.Velocity, cmd.Result.IsGrounded, cmd.Result.JumpFrames);
        } else
        {
            PMotor.State motorState = _motor.Move(cmd.Input.Forward, cmd.Input.Backward, cmd.Input.Left, cmd.Input.Right, cmd.Input.Jump, cmd.Input.Yaw);

            // copy the motor state to the commands result (this gets sent back to the client)
            cmd.Result.Position = motorState.position;
            cmd.Result.Velocity = motorState.velocity;
            cmd.Result.IsGrounded = motorState.isGrounded;
            cmd.Result.JumpFrames = motorState.jumpFrames;
        }
    }
}