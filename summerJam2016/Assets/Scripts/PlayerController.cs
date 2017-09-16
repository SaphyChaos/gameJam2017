using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float x;
	public float speed = 0.5f;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		x = Input.acceleration.x * speed;
		transform.Translate(x, 0, 0);
	}
}
