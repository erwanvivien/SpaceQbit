using Bolt;
using UnityEngine;

public class PController : Bolt.EntityBehaviour<IPlayerState>
{
    bool _forward;
    bool _backward;
    bool _left;
    bool _right;
    bool _dash;

    PMotor _motor;
    
    void Awake()
    {
    _motor = GetComponent<PMotor>();
    }

    public override void Attached()
    {
        state.SetTransforms(state.transform, transform);
    }
    
    void PollKeys()
    {
        _forward = Input.GetKey(KeyCode.Z);
        _backward = Input.GetKey(KeyCode.S);
        _left = Input.GetKey(KeyCode.Q);
        _right = Input.GetKey(KeyCode.D);
        _dash = Input.GetKeyDown(KeyCode.LeftShift);
    }
    
    void Update()
    {
        PollKeys();
    }
    
    public override void SimulateController()
    {
        PollKeys();

        IPlayerCommandInput input = PlayerCommand.Create();

        input.Forward = _forward;
        input.Backward = _backward;
        input.Left = _left;
        input.Right = _right;
        input.Dash = _dash;

        entity.QueueInput(input);
    }
    
    public override void ExecuteCommand(Command command, bool resetState)
    {
        PlayerCommand cmd = (PlayerCommand)command;

        if (resetState)
        {
            // we got a correction from the server, reset (this only runs on the client)
            _motor.SetState(cmd.Result.Position, cmd.Result.Velocity);
        }
        else
        {
            // apply movement (this runs on both server and client)
            PMotor.State motorState = _motor.Move(cmd.Input.Forward, cmd.Input.Backward, cmd.Input.Left, cmd.Input.Right);

            // copy the motor state to the commands result (this gets sent back to the client)
            cmd.Result.Position = motorState.position;
            cmd.Result.Velocity = motorState.velocity;
        }
    }
}