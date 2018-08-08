using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class combatScript2 : MonoBehaviour
    {
        //public Platformer2DUserControlCombat player1;
        public GameObject player1;
        public GameObject enemy1;
        public GameObject enemy2;
        public List<GameObject> array;
        public static int arrayIndex = 0;
        public int arrayMax = 2;
        public static Vector3 startPos;
        // Use this for initialization
        void Start()
        {
            array.Add(player1);
            array.Add(enemy1);
            array.Add(enemy2);
            if (dogHP.headShot)
                enemy1.GetComponent<Bird>().damage(10);
            dogHP.headShot = false;
            if (dogHP.backStab)
                enemy1.GetComponent<Bird>().damage(15);
            dogHP.backStab = false;
        }

        // Update is called once per frame
        void Update()
        {//This would work so much better if all were disabled, it went down a list, then enabled the member of that list
            if (player1.GetComponent<Platformer2DUserControlCombat>().passed)
            {
                //arrayIndex += 1;
                player1.GetComponent<Platformer2DUserControlCombat>().enabled = false;
            }
            if (enemy1.GetComponent<birdAI>().passed)
            {
                //arrayIndex += 1;
                enemy1.GetComponent<birdAI>().enabled = false;
                enemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            if (enemy2.GetComponent<botAI>().passed)
            {
                //arrayIndex += 1;
                enemy2.GetComponent<botAI>().enabled = false;
                enemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            //print(arrayIndex);
            if (arrayIndex >= arrayMax)
                arrayIndex = 0;
            if (array[arrayIndex] == enemy1)
            {
                enemy1.GetComponent<birdAI>().enabled = true;
                enemy1.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (array[arrayIndex] == enemy2)
            {
                enemy2.GetComponent<botAI>().enabled = true;
                enemy2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            if (array[arrayIndex] == player1)
            {
                player1.GetComponent<Platformer2DUserControlCombat>().enabled = true;
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