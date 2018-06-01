using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModelCenital : MonoBehaviour
{

    //Hide in inspector (o no, da un poco igual)
    float _x = 0, _y = 0;

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

        //_groundedActionState = new GroundedActionState(this);
        //_airborneActionState = new AirborneActionState(this);
    }

    void Start()
    {

    }

    void Update()
    {
        if (_rigidbody.velocity.x != 0)
        {
            _facingDirection = (int)(_rigidbody.velocity.x / Mathf.Abs(_rigidbody.velocity.x));
        }
        move(_x, _y);

    }
    void move(float _x, float _y)
    {

        _rigidbody.velocity = new Vector2(_x * Time.deltaTime, _y * Time.deltaTime);

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
