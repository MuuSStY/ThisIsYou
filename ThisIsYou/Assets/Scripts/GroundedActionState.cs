using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedActionState : ActionState {

    float _groundSkiddingDeceleration = 0.3f;
    float _groundReleaseDeceleration = 0.3f;
    float _xMaxGroundSpeed = 8f;
    float _xGroundAcceleration = 30f;
    float _highJumpGroundVelocityThreshold = 0f;
    float _yHighJumpVelocity0 = 7.5f;
    float _yHighJumpVelocity1 = 9f;

    public GroundedActionState(PlayerModel player) : base(player)
    {
    }

    public override void Tick()
    {
    }

    public override void OnStateEnter(ActionState lastState)
    {
        base.OnStateEnter(lastState);
    }

    public override void OnStateExit(ActionState nextState)
    {
        base.OnStateExit(nextState);
    }

    public override void MovementInput(float x, float y)
    {
        if (_lastX * x < 0)//Derrape
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * _groundSkiddingDeceleration, _rigidbody.velocity.y);
        }

        if (_lastX != 0 && x == 0)//Parón
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x * _groundReleaseDeceleration, _rigidbody.velocity.y);
        }
        if (Mathf.Abs(_rigidbody.velocity.x) < _xMaxGroundSpeed)//Si no va a velocidad máxima, acelera
        {
            _rigidbody.AddForce(Vector2.right * x * _xGroundAcceleration);
        }

        if (Mathf.Abs(_rigidbody.velocity.x) >= _xMaxGroundSpeed)//Restringe velocidad máxima  
        {
            _rigidbody.velocity = new Vector2((_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x)) * _xMaxGroundSpeed, _rigidbody.velocity.y);
        }

        base.MovementInput(x, y);

    }

    public override void OnJumpHighButton()
    {
        base.OnJumpHighButton();
        if (Mathf.Abs(_rigidbody.velocity.x) > _highJumpGroundVelocityThreshold)
        {
            _rigidbody.velocity += Vector2.up * _yHighJumpVelocity1;
        }
        else
        {
            _rigidbody.velocity += Vector2.up * _yHighJumpVelocity0;
        }
        //Si dejamos el cambio de estado para ground sensor podemos hacer una transición a jump squat antes de saltar, también sirve por si hay algún obstáculo que te impida saltar
    }
}
