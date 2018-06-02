using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerModelTopDown : MonoBehaviour
{

    //Hide in inspector (o no, da un poco igual)
    float _x = 0, _y = 0, movementspeed;
    
    [SerializeField] private float distanceToMove;
    [SerializeField] private float moveSpeed;
    public bool moveToPoint = false;
    private Vector2 endPosition;
    public Vector2 screenPos;

    public int _facingDirection = 1;
    public string tag_to_detect;
    public Vector2 _snapArea = new Vector2(2.5f, 2.5f);
    public Vector2 pos;
    private Vector2 pos_aux;
    public SexualitySlider slider;
    private Rigidbody2D _rigidbody;
    private ParticleSystem _particleSystem;
    private Transform tr;
    PaintTimer paintTimer;

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
        pos = transform.position;
        tr = transform;
        paintTimer = GetComponent<PaintTimer>();
        slider = FindObjectOfType<SexualitySlider>();
        //_groundedActionState = new GroundedActionState(this);
        //_airborneActionState = new AirborneActionState(this);
    }

    void Start()
    {
        endPosition = transform.position;
        movementspeed = 0.001f;
        StartCoroutine(paintTimer.CountTimeForSceneChange(60.0f));
    }

    void Update()
    {

        Vector2 t = new Vector2(transform.position.x, transform.position.y);
        if (Input.GetKey(KeyCode.A)) //Left
        {
            //endPosition += distanceToMove * Vector2.left;
            endPosition = new Vector2(endPosition.x - distanceToMove, endPosition.y);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.D)) //Right
        {
            //endPosition += distanceToMove * Vector2.right;
            endPosition = new Vector2(endPosition.x + distanceToMove, endPosition.y);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.W)) //Up
        {
            //endPosition += distanceToMove * Vector2.up;
            endPosition = new Vector2(endPosition.x, endPosition.y + distanceToMove);
            moveToPoint = true;
        }
        if (Input.GetKey(KeyCode.S)) //Down
        {
            endPosition = new Vector2(endPosition.x, endPosition.y - distanceToMove);
            //endPosition += distanceToMove * Vector2.down;
            moveToPoint = true;
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            moveToPoint = false;
        }
        else
        {
            slider.AddToBar(-0.01f);
        }
        

    }

    void FixedUpdate()
    {
        if (moveToPoint)
        {
            _rigidbody.MovePosition(endPosition * moveSpeed * Time.deltaTime);
            GameObject newObject = GameObject.Instantiate(Resources.Load("Prefabs/PintedPink")) as GameObject;
            newObject.transform.position = transform.position;
            //transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed * Time.deltaTime);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Recibir daño
        if (collision.tag == tag_to_detect)
        {
            Destroy(collision.gameObject);

        }
    }
}
