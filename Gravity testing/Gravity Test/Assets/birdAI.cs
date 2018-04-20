using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace UnityStandardAssets._2D
{
    public class birdAI : MonoBehaviour
    {
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
        private bool attacking;
        public GameObject protag;
        // Use this for initialization
        void Start()
        {
            passed = false;
            birdAPStart = 200;
            birdAP = 200;
            attacking = false;
        }
        void OnEnable()
        {
            passed = false;
            attacking = false;
            dumbTimer = 0;
            birdAP = birdAPStart;
            birdAnim.Play("flaping", -1, 0f);
        }
        // Update is called once per frame
        void Update()
        {
            //print(dumbTimer);
            dumbTimer += 1;
            if (dumbTimer > (60 * 60))
            {
                birdAnim.Play("Idle", -1, 0f);
                passed = true;
            }
            if (birdAP <= 0)
            {
                birdAnim.Play("Idle", -1, 0f);
                passed = true;
            }
            pcPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (Player.position.x > m_body.position.x)
            {
                move = 1;
            }
            else if (Player.position.x < m_body.position.x)
            {
                move = -1;
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
            if (Mathf.Abs(Player.position.x - m_body.position.x) <= 2.75)
            {
                move = 0;
                if (attacking == false)
                    meleeAttack();
                attacking = true;
                if (birdAnim.GetCurrentAnimatorStateInfo(0).IsName("doneAttack"))
                {
                    protag.GetComponent<Platformer2DUserControlCombat>().damage(25);
                    attacking = false;
                    passed = true;
                }
            }
            m_body.velocity = new Vector2(move * 2, m_body.velocity.y);
            birdAP -= 1;

        }
        private void meleeAttack()
        {
            birdAnim.Play("meleeAttack", -1, 0f);
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
}
