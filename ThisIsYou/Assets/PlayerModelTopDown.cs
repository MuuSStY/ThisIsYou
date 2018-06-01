using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModelTopDown : MonoBehaviour
{

    //Hide in inspector (o no, da un poco igual)
    float _x = 0, _y = 0, movementspeed;


    public int _facingDirection = 1;
    public Vector2 _snapArea = new Vector2(2.5f, 2.5f);

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
        _rigidbody.gravityScale = 0.0f;

        //_groundedActionState = new GroundedActionState(this);
        //_airborneActionState = new AirborneActionState(this);
    }

    void Start()
    {
        movementspeed = 2f;
    }

    void Update()
    {
        //_rigidbody.velocity = Vector3.zero;
        //_rigidbody.angularVelocity = 0;
        if (IsMoving())
        {
            if (_x < 0)
            {
                transform.Translate(Vector3.left * movementspeed * Time.deltaTime);
            }
            else if (_x > 0)
            {
                transform.Translate(Vector3.right * movementspeed * Time.deltaTime);
            }
            if (_y < 0)
            {
                transform.Translate(Vector3.down * movementspeed * Time.deltaTime);
            }
            else if (_y > 0)
            {
                transform.Translate(Vector3.up * movementspeed * Time.deltaTime);
            }
        }
        else
        {
            

        }

    }

    public bool IsMoving()
    {
        return (_x != 0 || _y != 0);
    }

    public void setPos(float x, float y)
    {
        _x = x;
        _y = y;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Recibir daño
    }
}
