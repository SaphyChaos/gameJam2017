using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWalk : MonoBehaviour {

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.
	private Transform player;				//Target and move toward player
	private bool isGrounded;            // Whether or not the player is grounded.

	public Transform enemy;
	public float speed = 1f;
	public float jumpForce = 400.0f;

	// Use this for initialization
	void Start () {
		//Get reference to player
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Move (enemy.position.x);
	}

	void Move (float h)
	{
		Vector3 scale = enemy.localScale;

		if (isGrounded && anim.GetBool("Ground") /*&& (wall or ledge ahead)*/)
		{
			// Add a vertical force to the player.
			isGrounded = true;
			anim.SetBool("Ground", false);
			rb2d.AddForce(new Vector2(0f, jumpForce));
		}

		if (h >= player.position.x) {
			if (scale.x < 0) 
			{
				scale.x *= -1;
				enemy.localScale = scale;
			}
			h -= 0.1f * speed;
		} 
		else 
		{
			/*if (scale.x > 0) 
			{
				scale.x *= -1;
				enemy.localScale = scale;
			}*/
			h += 0.1f * speed;
		}
		float y = enemy.position.y;
		enemy.position = new Vector3( h , y, 0.0f );
	}
}
