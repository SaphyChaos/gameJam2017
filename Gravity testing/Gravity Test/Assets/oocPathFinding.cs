using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oocPathFinding : MonoBehaviour
{
    //private Gameobject lineOfSight;
    public Rigidbody2D m_body;
    public bool iSeeYouFucker;
    public Rigidbody2D Player;
    private Vector3 pcPosition;
    private float timePassed;
    private float timer;
    private int move;
    private bool m_FacingRight = false;
    public GameObject bird;
    public Animator birdAnim;
    // Use this for initialization
    void Start()
    {
        //m_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iSeeYouFucker)
        {
            pcPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (Player.position.x > m_body.position.x)
            {
                move = 1;
                m_body.velocity = new Vector2(move, m_body.velocity.y);
            }
            else if (Player.position.x < m_body.position.x)
            {
                move = -1;
                m_body.velocity = new Vector2(move, m_body.velocity.y); ;
            }
        }
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
        if (iSeeYouFucker)
        {
            timePassed += Time.deltaTime;
            //print(timePassed);
        }
        if (timePassed >= timer)
        {
            iSeeYouFucker = false;
            timePassed = 0;
        }
        if (!iSeeYouFucker)
        {
            m_body.velocity = new Vector2(0, m_body.velocity.y);
            birdAnim.Play("Idle", -1, 0f);
        }
    }
    void FixedUpdate()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            iSeeYouFucker = true;
            timer = 5f;
            birdAnim.Play("flaping", -1, 0f);
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = bird.transform.localScale;
        theScale.x *= -1;
        bird.transform.localScale = theScale;
    }
}