using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModel : MonoBehaviour {

    //Hide in inspector (o no, da un poco igual)
    public bool _jumpButtonPressed = false;

    public int _facingDirection = 1;
    public Vector2 _snapArea = new Vector2(2.5f, 2.5f);

    public ActionState _currentActionState;
    public ActionState _airborneActionState;
    public ActionState _groundedActionState;

    private Rigidbody2D _rigidbody;
    private ParticleSystem _particleSystem;
    private GameManager gameManager;

    private bool canMove = true;
    private bool isDead = false;

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.white;
        //Gizmos.DrawWireCube(transform.position, new Vector3(_snapArea.x, _snapArea.y, 0));
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _particleSystem = GetComponent<ParticleSystem>();

        _groundedActionState = new GroundedActionState(this);
        _airborneActionState = new AirborneActionState(this);

        gameManager = FindObjectOfType<GameManager>();

        canMove = true;
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
        if (canMove)
        {
            _currentActionState.MovementInput(x, y);
        }
        else
        {
            _rigidbody.velocity = new Vector2(0.0f, 0.0f);
        }
    }

    public void OnJumpHighButton()
    {
        _currentActionState.OnJumpHighButton();
    }

    public bool IsJumping()
    {
        return _currentActionState == _airborneActionState;
    }

    public bool IsMoving()
    {
        return _rigidbody.velocity.x != 0f;
    }

    public bool IsDead(){
        return isDead;
    }

    public bool HasWon(){
        return true;
    }

    public int GetFacingDirection()
    {
        return _facingDirection;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Pinchito")
        {
            StartCoroutine(ResetLevel());
            canMove = false;
            isDead = true;
            _rigidbody.gravityScale = 0;
        }
        if (col.gameObject.tag == "Victory")
        {
            StartCoroutine(GoToNextLevel());
            canMove = false;
        }
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSeconds(1.0f);
        canMove = true;
        gameManager.ReloadCurrentScene();
    }

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(1.0f);
        canMove = true;
        gameManager.LoadScene(GameManager.ScenesToLoad.INTRO);
    }
}
