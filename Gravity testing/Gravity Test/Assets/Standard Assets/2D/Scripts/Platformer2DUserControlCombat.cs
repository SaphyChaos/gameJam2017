using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class Platformer2DUserControlCombat : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
        private SickRiff m_sickriff;
		private bool m_Jump;
		private float hbuff;
		//rudimentary kill floor setup (KF)
		public Transform respawn;
		private float killFloor;
		public int AP = 50;
		public int APStart = 50;
        private bool inSelect;
        private bool readyToDeselect;
        public GameObject textBox;
        public GameObject action;
        public GameObject selection;
        public GameObject self;
        public GameObject SpecialAttack;
        public GameObject passTurn;
        public Animator rifState;
        private bool canJumpAgain = true;
        private bool stillRiffing;

        void Start () {
			killFloor = -25.0f;
			APStart = 50;
			AP = 50;
		}
		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
            m_sickriff = SpecialAttack.GetComponent<SickRiff>();
		}


		private void Update()
		{
            /*if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				if (Input.touchCount > 0)
					m_Jump = true;
            }*/
            //print(Input.GetAxis("Jump"));
            if (Input.GetAxis("Jump") == 0)
            {
                canJumpAgain = true;
            }
            else//if ((!m_Jump) && (canJumpAgain == true))
            {
                if(canJumpAgain)
                    m_Jump = Input.GetAxis("Jump") > 0;
                canJumpAgain = false;
            }
			if (AP <= 0) {
                //print ("out of ap!");
                //Color tmp = passTurn.GetComponent<SpriteRenderer>().color;
                //tmp.a = 1f;
                //textBox.GetComponent<SpriteRenderer>().color = tmp;
                return;
			}
			//(KF)
			if (killFloor < (transform.position.y - 25.0f))
				killFloor = transform.position.y - 25.0f;
			if (transform.position.y < killFloor)
			{
				/*
				this.transform.position = respawn.position; 	//respawn at beginning
				this.transform.rotation = respawn.rotation;
				killFloor = transform.position.y - 25.0f;
				*/
				Application.LoadLevel ("Game Over");
			}
		}

        private void sickRiffAttack()
        {
            m_sickriff.enableIt();
            stillRiffing = true;
        }

        private void FixedUpdate()
        {
            if (stillRiffing)
            {
                if (rifState.GetCurrentAnimatorStateInfo(0).IsName("noAnimate"))
                {
                    stillRiffing = false;
                }
                else
                {
                    m_Character.Move(0, false, false);
                    return;
                }
            }
            float q = Input.GetAxis("Attack1");
            if ((inSelect == true) && (q == 0)) {
                readyToDeselect = true;
            }
            if ((inSelect == false) && (q == 0))
            {
                readyToDeselect = false;
            }
            if ((q > 0) && (readyToDeselect == false) && (m_Jump == false) && (m_Character.m_Grounded == true)) {
                inSelect = true;
                Color tmp = textBox.GetComponent<SpriteRenderer>().color;
                tmp.a = 1f;
                textBox.GetComponent<SpriteRenderer>().color = tmp;
                action.GetComponent<SpriteRenderer>().color = tmp;
                selection.GetComponent<SpriteRenderer>().color = tmp;
            }
            if ((q > 0) && (readyToDeselect == true) && (m_Jump == false) &&(m_Character.m_Grounded == true))
            {
                inSelect = false;
                Color tmp = textBox.GetComponent<SpriteRenderer>().color;
                tmp.a = 0f;
                textBox.GetComponent<SpriteRenderer>().color = tmp;
                action.GetComponent<SpriteRenderer>().color = tmp;
                selection.GetComponent<SpriteRenderer>().color = tmp;
            }
            if (inSelect == true)
            {
                m_Jump = Input.GetAxis("Jump") > 0;
                if (m_Jump == true)
                {
                    inSelect = false;
                    Color tmp = textBox.GetComponent<SpriteRenderer>().color;
                    tmp.a = 0f;
                    textBox.GetComponent<SpriteRenderer>().color = tmp;
                    action.GetComponent<SpriteRenderer>().color = tmp;
                    selection.GetComponent<SpriteRenderer>().color = tmp;
                    sickRiffAttack();
                    m_Jump = false;
                    canJumpAgain = false;
                    m_Character.Move(0, false, false);
                    return;
                }
            }
            if (inSelect == true) { 
                m_Character.Move(0, false, false);
                return;
            }
            if (AP <= 0) {
				//print ("out of ap!");
				m_Character.Move(0, false, false);
				return;
			}
			// Read the inputs.
			bool crouch = false;//Input.GetKey(KeyCode.LeftControl);
			float h = Input.GetAxis("Horizontal"); // We're not using andriod anymore so fuck this -> Input.acceleration.x; 
			float input = h;
			if (Mathf.Abs(hbuff) > Mathf.Abs(input))
				h = 0;
			if (h != 0) {
				AP -= 1;
			}
			//print ("fuckyou");
			//print (AP);
			//print(h);
            //print("are u getting called?!?!?" + " " + h + " " + m_Jump);
            // Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
            if (m_Character.m_Grounded == false)
                m_Jump = false;
			hbuff = input;
		}
	}
}
