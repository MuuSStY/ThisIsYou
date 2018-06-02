using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 direction;
	public float speed = 2.0f;

	new Rigidbody2D rigidbody;

	void Awake () {
		rigidbody = GetComponent<Rigidbody2D>();
		direction.z = 0;
		direction.Normalize();
	}
	
	void Update () {
		rigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
	}
}
