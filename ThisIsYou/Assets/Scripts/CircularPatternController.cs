using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularPatternController : MonoBehaviour
{

    private float _rotate_speed;
    private float _radius = 1.1f;

    private Vector2 _centre;
    private float _angle;

    private void Awake()
    {
        _rotate_speed = Random.Range(1.0f, 2.0f);
        _radius = Random.Range(1.0f, 3.0f);
        _centre = new Vector2(0.0f, 1.0f);
    }

    private void Update()
    {
        _angle += _rotate_speed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * _radius;
        transform.position = _centre + offset;
    }

    public float GetRotateSpeed()
    {
        return _rotate_speed;
    }
}
