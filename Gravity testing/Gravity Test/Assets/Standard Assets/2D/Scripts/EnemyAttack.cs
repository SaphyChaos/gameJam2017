using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;		//testing purposes
	public int attackDamage = 10;

	private Animator anim;
	private GameObject player;
	private PlatformerCharacter2DHealth playerHealth;
	//private EnemyHealth enemyHealth;
	private bool playerInRange;
	private float timer;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlatformerCharacter2DHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
		anim = GetComponent <Animator> ();
	}

	void onTriggerEnter (Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange = true;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject == player) 
		{
			playerInRange = false;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= timeBetweenAttacks && playerInRange /*&& enemyHealth.currentHealth > 0 */) 
		{
			Attack ();
		}

		if (playerHealth.currentHealth <= 0) 
		{
			anim.SetTrigger ("PlayerDead");
		}
	}

	void Attack ()
	{
		timer = 0f;
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.TakeDamage (attackDamage);
		}
	}
}
