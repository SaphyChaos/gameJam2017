using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
	[RequireComponent(typeof (PlatformerCharacter2D))]
	public class Platformer2DUserControlCombat : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
        private SickRiff m_sickriff;
		private bool m_Jump;
        private int m_selectMove;
        private int selectState;
        private float hbuff;
		//rudimentary kill floor setup (KF)
		public Transform respawn;
		private float killFloor;
		public int AP;
		public int APStart;
        public int HPStart;
        public int HP;
        private bool inSelect;
        private bool readyToDeselect;
        private bool selectBool;
        public GameObject textBox;
        public GameObject action;
        public GameObject basicAttack;
        public GameObject selection;
        public GameObject self;
        public GameObject SpecialAttack;
        public GameObject passTurn;
        public Animator rifState;
        public Animator dog;
        private bool canJumpAgain = true;
        private bool stillRiffing;
        public bool passed;

        void Start () {
			killFloor = -25.0f;
            HPStart = 50;
            HP = dogHP.HP;
			APStart = 30;
			AP = 30;
            passed = false;
		}
		private void Awake()
		{
			m_Character = GetComponent<PlatformerCharacter2D>();
            m_sickriff = SpecialAttack.GetComponent<SickRiff>();
		}
        void OnEnable()
        {
            AP = APStart;
            passed = false;
            m_sickriff.hitHim = false;
            m_sickriff.hitHimBasic = false;
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
            dogHP.HP = HP;
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
            //if (AP <= 0) {
            //print ("out of ap!");
            //Color tmp = passTurn.GetComponent<Image>().color;
            //tmp.a = 1f;
            //textBox.GetComponent<Image>().color = tmp;
            //    return;
            //}
            if (Input.GetAxis("Submit") != 0)
            {
                passed = true;
                AP = 0;
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
        private void doBasicAttack()
        {
            m_sickriff.enableItBasic();
            dog.Play("guitarSmash", -1, 0f);
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
                Color tmp = textBox.GetComponent<Image>().color;
                tmp.a = 1f;
                Color fade = action.GetComponent<Image>().color;
                fade.a = .25f;
                textBox.GetComponent<Image>().color = tmp;
                if (AP < 30)
                    action.GetComponent<Image>().color = fade;
                else
                    action.GetComponent<Image>().color = tmp;
                if (AP < 5)
                    basicAttack.GetComponent<Image>().color = fade;
                else
                    basicAttack.GetComponent<Image>().color = tmp;
                selection.GetComponent<Image>().color = tmp;
            }
            if ((q > 0) && (readyToDeselect == true) && (m_Jump == false) &&(m_Character.m_Grounded == true))
            {
                inSelect = false;
                Color tmp = textBox.GetComponent<Image>().color;
                tmp.a = 0f;
                textBox.GetComponent<Image>().color = tmp;
                action.GetComponent<Image>().color = tmp;
                selection.GetComponent<Image>().color = tmp;
                basicAttack.GetComponent<Image>().color = tmp;
            }
            if (inSelect == true)
            {
                if(selectBool == true){
                    if (Input.GetAxis("Vertical") > 0)
                        m_selectMove = 1;
                    else if (Input.GetAxis("Vertical") < 0)
                        m_selectMove = -1;
                }
                if (Input.GetAxis("Vertical") == 0)
                    m_selectMove = 0;
                if (Input.GetAxis("Vertical") == 0)
                    selectBool = true;
                else
                    selectBool = false;
                m_Jump = Input.GetAxis("Jump") > 0;
                if(m_selectMove == 1)
                {
                    if (selectState == 0)
                        selectState = 0;
                    else
                        selectState -= 1;
                }
                if (m_selectMove == -1)
                {
                    if (selectState == 1)
                        selectState = 1;
                    else
                        selectState += 1;
                }
                if(selectState == 0)
                {
                    selection.transform.position = new Vector3(selection.transform.position.x, action.transform.position.y, selection.transform.position.z);
                }
                else if (selectState == 1)
                {
                    selection.transform.position = new Vector3(selection.transform.position.x, basicAttack.transform.position.y, selection.transform.position.z);
                }

                if ((m_Jump == true) && (AP >= 30) && (selectState == 0))
                {
                    inSelect = false;
                    Color tmp = textBox.GetComponent<Image>().color;
                    tmp.a = 0f;
                    textBox.GetComponent<Image>().color = tmp;
                    action.GetComponent<Image>().color = tmp;
                    selection.GetComponent<Image>().color = tmp;
                    basicAttack.GetComponent<Image>().color = tmp;
                    sickRiffAttack();
                    m_Jump = false;
                    canJumpAgain = false;
                    m_Character.Move(0, false, false);
                    AP = 0;
                    return;
                }
                if ((m_Jump == true) && (AP >= 5) && (selectState == 1))
                {
                    inSelect = false;
                    Color tmp = textBox.GetComponent<Image>().color;
                    tmp.a = 0f;
                    textBox.GetComponent<Image>().color = tmp;
                    action.GetComponent<Image>().color = tmp;
                    selection.GetComponent<Image>().color = tmp;
                    basicAttack.GetComponent<Image>().color = tmp;
                    doBasicAttack();
                    m_Jump = false;
                    canJumpAgain = false;
                    m_Character.Move(0, false, false);
                    AP = 0;
                    return;
                }
            }
            if (inSelect == true) { 
                m_Character.Move(0, false, false);
                return;
            }
            if (AP <= 0) {
                //print ("out of ap!");
                m_sickriff.hitHim = false;
                m_sickriff.hitHimBasic = false;
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
        public void damage(int x)
        {
            //print(health);
            HP -= x;
            if (HP <= 0)
            {
                Application.LoadLevel("Game Over");
            }
        }
    }
}
