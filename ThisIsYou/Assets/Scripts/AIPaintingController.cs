using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPaintingController : MonoBehaviour
{
    public SexualitySlider slider;
    private Transform target_transform;
    public float move_speed;
    public string tag_to_detect;
    public float rotation_speed;
    // Use this for initialization
    void Awake()
    {
        GameObject target_object = GameObject.FindGameObjectWithTag("Player");
        target_transform = target_object.transform;
        slider = FindObjectOfType<SexualitySlider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target_transform.position - transform.position).normalized * move_speed * Time.deltaTime;
        GameObject newObject = GameObject.Instantiate(Resources.Load("Prefabs/PaintedBlue")) as GameObject;
        newObject.transform.position = transform.position;
        slider.AddToBar(0.01f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tag_to_detect)
        {
            
            Destroy(collision.gameObject);
        }
    }
}
