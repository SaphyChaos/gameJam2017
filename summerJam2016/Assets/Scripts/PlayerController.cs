using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float x;
	public float speed = 0.5f;
	public Transform respawn;
	private float killFloor = -5.0f;
	//private Touch tap;

	// Use this for initialization
	void Start () {
		killFloor = -5.0f;
	}

	// Update is called once per frame
	void Update () {
		//tap = Input.GetTouch(0);//touches[0];
		if (Input.GetMouseButtonDown(0))//GetTouch(0).tapCount > 0)
			transform.position.y++;
		if (killFloor < (transform.position.y - 5))
			killFloor = transform.position.y - 5;
		x = Input.acceleration.x * speed;
		transform.Translate(x, 0, 0);

		if (transform.position.y < -5)
		{
			this.transform.position = respawn.position; 	//respawn at begining
			this.transform.rotation = respawn.rotation;
		}
		
	}
}
