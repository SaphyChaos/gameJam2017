using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public unsafe class MeterScriptHPEnemy : MonoBehaviour
    {
        public Image image;
        private Bird birdScript;
        private float frak;
        private int* myAP;
        private int* myAPStart;
        //public bool coolingDown;
        //public float waitTime = 30.0f;
        //public float myFillamount =0f;

        //private void Awake(){
        //	cooldown = GetComponent<Image>;
        //}
        // Update is called once per frame
        void Start()
        {
            GameObject theEnemy = GameObject.Find("Bird");
            //image = theEnemy.GetComponent<Image>();
            birdScript = theEnemy.GetComponent<Bird>();
        }
        void Update()
        {
            frak = birdScript.health;
            image.fillAmount = (frak / birdScript.healthStart);
        }
    }
}