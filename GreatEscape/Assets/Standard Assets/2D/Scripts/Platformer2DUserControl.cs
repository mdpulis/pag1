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
		private bool c_Turn;
		private int turn = 1;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {

			if (!m_Jump) {
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = CrossPlatformInputManager.GetButtonDown ("Jump");

			}


			//change directions if 'T' is pressed
			if (Input.GetKey(KeyCode.T)) {
				if(turn == 1){
					turn = -1;
			} else if(turn == -1){
					turn = 1;
				}
		}
	}


        private void FixedUpdate()
        {
            // Read the inputs.
        	// bool crouch = Input.GetKey(KeyCode.LeftControl);
            // float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.

			//player cannot crouch (false) and is always running right (1)
            m_Character.Move(turn, false, m_Jump);
            m_Jump = false;
        }
    }
}
