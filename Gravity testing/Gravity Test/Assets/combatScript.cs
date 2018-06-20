using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class combatScript : MonoBehaviour
    {
        //public Platformer2DUserControlCombat player1;
        public GameObject player1;
        public GameObject enemy1;
        // Use this for initialization
        void Start()
        {
            if(dogHP.headShot)
                enemy1.GetComponent<Bird>().damage(10);
            dogHP.headShot = false;
        }

        // Update is called once per frame
        void Update()
        {//This would work so much better if all were disabled, it went down a list, then enabled the member of that list
            if (player1.GetComponent<Platformer2DUserControlCombat>().passed)
            {
                player1.GetComponent<Platformer2DUserControlCombat>().enabled = false;
                enemy1.GetComponent<birdAI>().enabled = true;
                enemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (enemy1.GetComponent<birdAI>().passed)
            {
                enemy1.GetComponent<birdAI>().enabled = false;
                player1.GetComponent<Platformer2DUserControlCombat>().enabled = true;
                enemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            /*
            if ((enemy1.GetComponent<birdAI>().passed) && (player1.GetComponent<Platformer2DUserControlCombat>().passed))
            {
                player1.GetComponent<Platformer2DUserControlCombat>().enabled = true;
            }
            if ((enemy1.GetComponent<birdAI>().passed) && (player1.GetComponent<Platformer2DUserControlCombat>().passed))
            {
                enemy1.GetComponent<birdAI>().enabled = true;
            }
            */
        }
    }
}