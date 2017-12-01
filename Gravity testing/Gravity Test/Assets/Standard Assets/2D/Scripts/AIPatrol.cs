using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour {


	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.
	private Transform player;				//Target and move toward player
	public Transform enemy;
	public float speed = 1.0f;
	public bool facingLeft = true;

	public float leftBound = -15.0f;
	public float rightBound = 5.0f;
	private float start;
	// Use this for initialization
	void Start () 
	{
		//Get reference to player
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();		
		start = enemy.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		Move (enemy.position.x);
	}

	void Move (float h)
	{
		Vector3 scale = enemy.localScale;
		if (facingLeft) 
		{
			if (h > start + leftBound) 
			{
				if (scale.x < 0) 
				{
					scale.x *= -1;
					enemy.localScale = scale;
				}
				h -= 0.1f * speed;
			} 
			else
				facingLeft = false;
		}
			
		else 
		{
			if (h < start + rightBound) 
			{
				if (scale.x > 0) 
				{
					scale.x *= -1;
					enemy.localScale = scale;
				}
				h += 0.1f * speed;
			} 
			else
				facingLeft = true;
		}
		enemy.position = new Vector3( h , 0.0f , 0.0f );
	}
}
