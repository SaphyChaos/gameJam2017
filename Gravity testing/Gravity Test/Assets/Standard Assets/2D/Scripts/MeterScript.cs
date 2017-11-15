using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public unsafe class MeterScript : MonoBehaviour
    {
        public Image FUCK;
        private Platformer2DUserControlCombat playerScript;
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
            GameObject thePlayer = GameObject.Find("CharacterRobotBoy");
            playerScript = thePlayer.GetComponent<Platformer2DUserControlCombat>();
        }
        void Update()
        {
            frak = playerScript.AP;
            FUCK.fillAmount = (frak / playerScript.APStart);
        }
    }
}