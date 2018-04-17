using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdAI : MonoBehaviour {
    public bool passed;
    private int dumbTimer;
    private Vector3 pcPosition;
    //public GameObject moveScript;
    private int move;
    private bool m_FacingRight;
    public Rigidbody2D Player;
    public int birdAPStart;
    public int birdAP;
    public GameObject bird;
    public Rigidbody2D m_body;
    public Animator birdAnim;
    // Use this for initialization
    void Start () {
        passed = false;
        birdAPStart = 200;
        birdAP = 200;
	}
    void OnEnable()
    {
        passed = false;
        dumbTimer = 0;
        birdAP = birdAPStart;
        birdAnim.Play("flaping", -1, 0f);
    }
    // Update is called once per frame
    void Update () {
        //print(dumbTimer);
        dumbTimer += 1;
		if (dumbTimer > (60*60))
        {
            birdAnim.Play("Idle", -1, 0f);
            passed = true;
        }
        if(birdAP <= 0)
        {
            birdAnim.Play("Idle", -1, 0f);
            passed = true;
        }
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
        birdAP -= 1;

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
