using System.Collections;
using UnityEngine;

public class runner : MonoBehaviour {
    public bool facingRight = true;
    public bool jump = false;
    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000;
    private bool isDead = false;

    private Animator anim;
    private Rigidbody2D rb2d;
    private Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;			// Whether or not the player is grounded.
    // Use this for initialization
    void Start () {
        //GetComponent<Rigidbody>().freezeRotation = true;
        //Get reference to the Animator component attached to this GameObject.
        anim = GetComponent<Animator>();
        //Get and store a reference to the Rigidbody2D attached to this GameObject.
        groundCheck = transform.Find("groundCheck");
        rb2d = GetComponent<Rigidbody2D>();
        print("Help!");
    }

    // Update is called once per frame
    void Update() {
        //Don't allow control if the runner has died.
        // The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("ground"));

        // If the jump button is pressed and the player is grounded then the player should jump.
        if (Input.GetButtonDown("Jump") && grounded)
            jump = true;
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }
    private void FixedUpdate()
    {
    // Cache the horizontal input.
    float h = Input.GetAxis("Horizontal");
        if(h == 0)
        {
			//var forceToAdd : Vector3 = Vector3(0,0,0);
			//print("ntohing!");
			//rb2d.velocity = Vector3.zero;
        }
        //The Speed animator parameter is set to the absolute value of the horizontal input.
        anim.SetFloat("Speed", Mathf.Abs(h));

        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            //GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
            GetComponent<Rigidbody2D>().velocity = Vector2.right * h * moveForce;

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        // If the input is moving the player right and the player is facing left...
        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();
        // If the player should jump...
        if (jump)
        {
            // Add a vertical force to the player.
            //print("jump yeah!");
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            //GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            jump = false;
        }
    }
    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
