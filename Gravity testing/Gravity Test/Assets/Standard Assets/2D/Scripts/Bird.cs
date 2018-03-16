using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;					//Upward force of the "flap".
	private bool isDead = false;			//Has the player collided with a wall?
    public int health;
    public Animator curtL;
    public Animator curtR;
    //public Sprite deathSprite;

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;				//Holds a reference to the Rigidbody2D component of the bird.

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
        health = 100;
	}

	void Update()
	{
        //float h = Input.GetAxis ("Horizontal");
        //Don't allow control if the bird has died.
        //Vector2 speed = rb2d.velocity;
        float h = Input.GetAxis("Horizontal");
        if (curtR.GetCurrentAnimatorStateInfo(0).IsName("curtainAnimBackEnd"))
        {
            Application.LoadLevel("RPGFieldAfterCombat");
        }
        //anim.SetFloat("Speed", Mathf.Abs(1));
        //if (isDead == false) {
        //Look for input to trigger a "flap".
        //if (Input.GetMouseButtonDown(0)) 
        //...tell the animator about it and then...
        //anim.SetTrigger ("Flap");
        //...zero out the birds current y velocity before...
        //rb2d.velocity = Vector2.zero;
        //	new Vector2(rb2d.velocity.x, 0);
        //..giving the bird some upward force.
        //rb2d.AddForce(new Vector2(0, upForce));
        //}
    }
    public void damage(int x)
    {
        //print(health);
        health -= x;
        if (health <= 0)
        {
            print("dead!");
            isDead = true;
            anim.Play("Die");
            //this.GetComponent<SpriteRenderer>().sprite = deathSprite;
            curtR.Play("curtAnimBack", -1, 0f);
            curtL.Play("curtAnimBack", -1, 0f);
        }
    }
	/*void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	*/
}