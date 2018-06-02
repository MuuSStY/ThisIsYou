using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPaintingController : MonoBehaviour {

    public string tag_to_detect;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == tag_to_detect)
        {
            int j = 0;
        }
    }
}
