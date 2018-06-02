using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	public float teleportDistance = 17.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	 void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
			Vector3 position = col.gameObject.transform.position;
            col.gameObject.transform.position = new Vector3(position.x,position.y - teleportDistance, position.z);
        }
    }
}
