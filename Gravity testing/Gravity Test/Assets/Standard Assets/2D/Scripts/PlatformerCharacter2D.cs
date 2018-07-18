using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce;                  // Amount of force added when the player jumps.
        [SerializeField] private float m_GravityScaleWithHeight = 0.1f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
		[SerializeField] private bool m_AirControl = true;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = 5.2f; // Radius of the overlap circle to determine if grounded was 2.2
        public bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        public bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private float timer;
        private float timePassed;
        private float r;//r is used for rotation during the shift state
        private bool bhopBool;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            //print(m_Rigidbody2D.velocity);
            m_Grounded = false;
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapBoxAll(m_GroundCheck.position, new Vector2(1.5f, k_GroundedRadius), m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if ((colliders[i].gameObject != gameObject) && (colliders[i].gameObject != GameObject.Find("lineOfSight")) && (colliders[i].gameObject != GameObject.Find("Head")) && (colliders[i].gameObject != GameObject.Find("Back")) && (colliders[i].gameObject != GameObject.Find("DumbBird")))
                {
                    //print(colliders[i].gameObject);
                    m_Grounded = true;
                }
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.gravityScale = Math.Min(3.0f/((Math.Max(1+ m_GravityScaleWithHeight * transform.position.y,1.0f))),3.0f);
            //m_Rigidbody2D.gravityScale = 3.0f / m_GravityScaleWithHeight * (transform.position.y + 1);
        }


        public void Move(float move, bool crouch, bool jump, bool shift)
        {
			//print("i'm moving :333 " + move + ", " + crouch + ", " + jump);
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
				if(move !=0)
					move = Mathf.Sign(move);
                if (move == 0 || Mathf.Abs(m_Rigidbody2D.velocity[0]) < Mathf.Abs(move * m_MaxSpeed))
                {
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
                }
                //else if (move == 0)
                //{
                 //   m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
                //}
                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                bhopBool = true;
				if(m_Rigidbody2D.velocity[1] < 5)
                	m_Rigidbody2D.AddForce(new Vector2(m_Rigidbody2D.velocity[0], m_JumpForce));
                if (m_Rigidbody2D.velocity[1] > m_JumpForce)
                    m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity[0], -m_JumpForce);
                    
            }
            if (!m_Grounded && m_AirControl && !m_Anim.GetBool("Ground"))
            {
                //timePassed = timePassed - timer;
                //timer = Time.time;
                //timePassed = timePassed + timer;
                //print(Mathf.Abs(hit.point.y - transform.position.y));
                if (!jump)
                {
                    //print("ha");
                    bhopBool = true;
                }
                //print(m_Rigidbody2D.velocity.y);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down, 1000, 12);
                //print(Mathf.Abs(hit.point.y - transform.position.y));
                if (bhopBool && m_Rigidbody2D.velocity.y < 0 && jump && Mathf.Abs(hit.point.y - transform.position.y) < 3 && jump && Mathf.Abs(hit.point.y - transform.position.y) > 2.5)
                {
                    bhopBool = false;
                    //print("he");
                    print(Mathf.Abs(hit.point.y - transform.position.y));
                }
                if (!bhopBool && Mathf.Abs(hit.point.y - transform.position.y) < 2.5 && m_Rigidbody2D.velocity.y < 0)
                {
                    print("ho");
                    //print(Mathf.Abs(hit.point.y - transform.position.y));
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
                    //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 0, 255);
                }

                

                //else if (jump && Physics.Raycast(transform.poshition, transform.TransformDirection(Vector3.down), out hit, 100, 11))
                //{

                  //  m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);
                    //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0, 255, 255);
                //}
            }
            if (m_Grounded && shift && m_Anim.GetBool("Ground"))
            {
                timePassed = timePassed - timer;
                timer = Time.time;
                timePassed = timePassed + timer;
                r = timePassed / .75f;
                //print(timePassed);
                if (timePassed > .75f)
                {
                    //print("heh");
                    this.gameObject.GetComponent<Platformer2DUserControl>().m_Shift = false;
                    timePassed = 0;
                    this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                    //m_Rigidbody2D.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (timePassed > .2f)
                {
                    //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
                    if (Input.GetAxis("Shift") == 0)
                    {
                        //m_Rigidbody2D.transform.eulerAngles = new Vector3(0, r, 0);
                        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed * 2, m_Rigidbody2D.velocity.y);
                        //this.gameObject.GetComponent<SpriteRenderer>().color = new Color(UnityEngine.Random.Range(0f, 1.0f), UnityEngine.Random.Range(0f, 1.0f), UnityEngine.Random.Range(0f, 1.0f));
                        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                    }
                    else
                    {
                        m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed * .5f, m_Rigidbody2D.velocity.y);
                        timePassed = 0;
                        this.gameObject.GetComponent<Platformer2DUserControl>().m_Shift = false;
                        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
                        //m_Rigidbody2D.transform.eulerAngles = new Vector3(0,0,0);
                    }
                }
                else
                {
                    m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed * .5f, m_Rigidbody2D.velocity.y);
                    if(this.gameObject.GetComponent<Platformer2DUserControl>().m_Shift == true)
                        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(.5f, .5f, .5f);
                }
                //timePassed = 0;
            }

            if (move == 0)
            {
                //m_Anim.Play("Idle", -1, 0f);
            }
        }


        public void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
