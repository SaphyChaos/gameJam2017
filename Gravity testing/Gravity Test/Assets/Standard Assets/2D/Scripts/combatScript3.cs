using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class combatScript3 : MonoBehaviour
    {
        //public Platformer2DUserControlCombat player1;
        public GameObject player1;
        public GameObject enemy1;
        public static GameObject[] brains;
        public static Vector3 startPos;
        public static int arrayIndex;
        public int arrayMax;
        // Use this for initialization
        void Start()
        {
            brains = GameObject.FindGameObjectsWithTag("brain");
            for (int i = 0; i < brains.Length; i++)
                brains[i].SetActive(false);
            for(int i = 0; i < brains.Length; i++)
            {
                if (brains[i].transform.parent.tag == "Enemy")
                {
                    enemy1 = brains[i];
                    break;
                }
            }
            print(brains.Length);
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
            //print(arrayIndex);
            if (arrayIndex >= brains.Length)
                arrayIndex = 0;
            for (int i = 0; i < brains.Length; i++)
                if (brains[i] != brains[arrayIndex])
                    brains[i].SetActive(false);
                else
                    brains[i].SetActive(true);
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