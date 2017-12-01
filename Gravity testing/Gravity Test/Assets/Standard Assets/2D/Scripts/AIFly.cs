using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AIFly : MonoBehaviour 
{

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.
	private Transform player;				//Target and move toward player
	public Transform enemy;
	public float speed = 1f;

	void Start()
	{
		//Get reference to player
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		Move (enemy.position.x, enemy.position.y);
	}

	//clean up rapid flipping
	void Move (float h, float v)
	{
		Vector3 scale = enemy.localScale;
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
			if (scale.x > 0) 
			{
				scale.x *= -1;
				enemy.localScale = scale;
			}
			h += 0.1f * speed;
		}
		if (v >= player.position.y)
			v -= 0.1f * speed;
		else
			v += 0.1f * speed;

		enemy.position = new Vector3( h , v , 0.0f );
	}
}