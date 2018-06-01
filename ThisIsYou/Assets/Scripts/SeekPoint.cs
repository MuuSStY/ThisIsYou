using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekPoint : MonoBehaviour
{
    public bool active;
    public Vector2 _position_to_seek;
    public float _velocity;
    // Use this for initialization

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), _position_to_seek, _velocity * Time.deltaTime);

            
            if (Vector2.Equals(new Vector2(transform.position.x, transform.position.y), _position_to_seek))
            {
                
            }
        }
    }
}
