using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
namespace UnityStandardAssets._2D
{
    public class botAI : MonoBehaviour
    {
        public bool passed;
        private int dumbTimer;
        private Vector3 pcPosition;
        //public GameObject moveScript;
        private int move;
        private bool m_FacingRight;
        public Rigidbody2D Player;
        public int botAPStart;
        public int botAP;
        public GameObject bot;
        public Rigidbody2D m_body;
        public Animator botAnim;
        private bool attacking;
        public GameObject protag;
        // Use this for initialization
        void Start()
        {
            passed = false;
            botAPStart = 200;
            botAP = 200;
            attacking = false;
        }
        void OnEnable()
        {
            passed = false;
            attacking = false;
            dumbTimer = 0;
            botAP = botAPStart;
            botAnim.Play("Walk", -1, 0f);
        }
        // Update is called once per frame
        void Update()
        {
            //print(dumbTimer);
            dumbTimer += 1;
            if (dumbTimer > (60 * 60))
            {
                botAnim.Play("Idle", -1, 0f);
                passed = true;
                combatScript3.arrayIndex += 1;
            }
            if (botAP <= 0)
            {
                botAnim.Play("Idle", -1, 0f);
                combatScript3.arrayIndex += 1;
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
            if (Mathf.Abs(Player.position.x - m_body.position.x) <= 6.75)
            {
                move = 0;
                if (attacking == false)
                    meleeAttack();
                attacking = true;
                if (botAnim.GetCurrentAnimatorStateInfo(0).IsName("doneAttack") && passed == false)
                {
                    protag.GetComponent<Platformer2DUserControlCombat>().damage(3);
                    attacking = false;
                    passed = true;
                }
            }
            m_body.velocity = new Vector2(move * 4, m_body.velocity.y);
            botAP -= 2;

        }
        private void meleeAttack()
        {
            botAnim.Play("Jumping", -1, 0f);
        }
        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = bot.transform.localScale;
            theScale.x *= -1;
            bot.transform.localScale = theScale;
        }
    }
}
