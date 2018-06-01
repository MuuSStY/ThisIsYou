using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaintingController : MonoBehaviour
{

    private Transform target_transform;
    public float move_speed;
    public float rotation_speed;
    // Use this for initialization
    void Awake()
    {
        GameObject target_object = GameObject.FindGameObjectWithTag("Player");
        target_transform = target_object.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target_transform.position - transform.position).normalized * move_speed * Time.deltaTime;
        GameObject newObject = GameObject.Instantiate(Resources.Load("Prefabs/BoyFloor")) as GameObject;
        newObject.transform.position = transform.position;
        
    }
}
