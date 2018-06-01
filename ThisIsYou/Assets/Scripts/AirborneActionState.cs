using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneActionState : ActionState
{

    float _gravityFallMultiplier = 2.3f;
    float _gravityLowJumpMultiplier = 2f;
    float _yMaxAirSpeed = 15f;
    float _horizontalAirVelocityThreshold = 0f;
    float _airAcceleration0 = 10f;
    float _airAcceleration1 = 15f;
    float _airAcceleration2 = 12f;
    float _losingMomentumGroundVelocityThreshold = 0f;
    float _xMaxAirSpeed = 8f;

    float _initialXVelocity = 0f;


    public AirborneActionState(PlayerModel player) : base(player)
    {
    }

    public override void Tick()
    {

        if (_rigidbody.velocity.y < 0)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_gravityFallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && _player._jumpButtonPressed == false)
        {
            _rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (_gravityLowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Mathf.Abs(_rigidbody.velocity.y) > _yMaxAirSpeed)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, (_rigidbody.velocity.y / Mathf.Abs(_rigidbody.velocity.y)) * _yMaxAirSpeed);
        }
    }

    public override void OnStateEnter(ActionState lastState)
    {
        base.OnStateEnter(lastState);
        _initialXVelocity = _rigidbody.velocity.x;
    }

    public override void OnStateExit(ActionState nextState)
    {
        base.OnStateExit(nextState);
    }

    public override void MovementInput(float x, float y)
    {
        //a favor del momentum
        if (x * _initialXVelocity > 0)
        {
            if (Mathf.Abs(_rigidbody.velocity.x) < _horizontalAirVelocityThreshold)//Si va lento, acelera menos
            {
                _rigidbody.AddForce(Vector2.right * x * _airAcceleration0);
            }
            else //Si va rápido, acelera más
            {
                _rigidbody.AddForce(Vector2.right * x * _airAcceleration1);
            }
        }
        else if (x * _initialXVelocity < 0 || _initialXVelocity == 0)//en contra del momentum, sin pulsar nada sigue el arco
        {
            if (Mathf.Abs(_rigidbody.velocity.x) >= _horizontalAirVelocityThreshold)//Si va rápido pierde momentum también rápido
            {
                _rigidbody.AddForce(Vector2.right * x * _airAcceleration1);
            }
            else if (Mathf.Abs(_initialXVelocity) >= _losingMomentumGroundVelocityThreshold)//Si ha empezado el salto yendo a mucha velocidad, puede perder momentum más rápido
            {
                _rigidbody.AddForce(Vector2.right * x * _airAcceleration2);
            }
            else
            {
                _rigidbody.AddForce(Vector2.right * x * _airAcceleration0);
            }
        }

        //Restringir máximo
        if (Mathf.Abs(_rigidbody.velocity.x) > _xMaxAirSpeed)
        {
            _rigidbody.velocity = new Vector2((_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x)) * _xMaxAirSpeed, _rigidbody.velocity.y);
        }

        base.MovementInput(x, y);
    }
}
