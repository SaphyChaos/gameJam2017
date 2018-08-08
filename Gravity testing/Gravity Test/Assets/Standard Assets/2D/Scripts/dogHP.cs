using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    public class dogHP : MonoBehaviour
    {
        public static int HP = 20;
        public static bool headShot = false;
        public static bool backStab = false;
        public static float globalTimer;
        public static bool bufferTime;
    // Use this for initialization
    void Start()
        {
            //HP = 50;
            //print(HP);
        }

        // Update is called once per frame
        void Update()
        {
        if(bufferTime)
            globalTimer += Time.deltaTime;
            //print(HP);
        }
    public static void Reset()
    {
    HP = 20;
    headShot = false;
    backStab = false;
    globalTimer = 0;
    bufferTime = false;
    }
}