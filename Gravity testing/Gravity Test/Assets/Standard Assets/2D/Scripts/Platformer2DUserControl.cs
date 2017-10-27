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
				m_Jump = Input.GetAxis ("Jump") > 0;

			//(KF)
			if (killFloor < (transform.position.y - 25.0f))
				killFloor = transform.position.y - 25.0f;
			if (transform.position.y < killFloor)
			{
				Application.LoadLevel ("Game Over");
			}
        }


        private void FixedUpdate()
        {
            // Read the inputs.
			bool crouch = false;//Input.GetKey(KeyCode.LeftControl);
			float h = Input.GetAxis("Horizontal"); // We're not using andriod anymore so fuck this -> Input.acceleration.x; 
			print("are u getting called?!?!?" + " " + h + " " + m_Jump);
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
