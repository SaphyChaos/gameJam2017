using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;

		//rudimentary kill floor setup (KF)
		public Transform respawn;
		private float killFloor;

		void Start () {
			killFloor = -25.0f;
		}
        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
				if (Input.touchCount > 0)
					m_Jump = true;//CrossPlatformInputManager.GetButtonDown("Jump");
            }
			//(KF)
			if (killFloor < (transform.position.y - 25.0f))
				killFloor = transform.position.y - 25.0f;
			if (transform.position.y < killFloor)
			{
				this.transform.position = respawn.position; 	//respawn at beginning
				this.transform.rotation = respawn.rotation;
				killFloor = transform.position.y - 25.0f;
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
			bool crouch = false;//Input.GetKey(KeyCode.LeftControl);
			float h = Input.acceleration.x;//CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
