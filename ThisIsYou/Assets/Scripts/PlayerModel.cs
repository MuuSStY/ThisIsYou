using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour {

    //Hide in inspector (o no, da un poco igual)
    public bool _jumpButtonPressed = false;
    public bool _isLongJump = false;

    public int _facingDirection = 1;
    public Vector2 _snapArea = new Vector2(2.5f, 2.5f);

    public ActionState _currentActionState;
    public ActionState _airborneActionState;
    public ActionState _groundedActionState;

    private Rigidbody2D _rigidbody;
    private ParticleSystem _particleSystem;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(transform.position, new Vector3(_snapArea.x, _snapArea.y, 0));
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponent<ParticleSystem>();

        _groundedActionState = new GroundedActionState(this);
        _airborneActionState = new AirborneActionState(this);
    }

    void Start ()
    {
        SetActionState(_airborneActionState); 
    }
	
	void Update ()
    {
        if (_rigidbody.velocity.x != 0)
        {
            _facingDirection = (int)(_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x));
        }
        _currentActionState.Tick();

	}

    public void SetActionState(ActionState state)
    {
        if (_currentActionState != null)
        {
            _currentActionState.OnStateExit(state);
        }
        ActionState exitingState = _currentActionState;
        _currentActionState = state;
        gameObject.name = "Jugador - " + state.GetType().Name;

        if (_currentActionState != null)
        {
            _currentActionState.OnStateEnter(exitingState);
        }
    }

    public void DirectionBindings(float x, float y)
    {
        _currentActionState.MovementInput(x, y);
    }

    public void OnJumpHighButton()
    {
        _currentActionState.OnJumpHighButton();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Recibir daño
    }
}
