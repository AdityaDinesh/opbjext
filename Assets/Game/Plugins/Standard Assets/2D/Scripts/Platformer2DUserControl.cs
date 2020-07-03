using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    public class SFX
    {
        public AudioClip Die;
        public AudioClip Jump;
        public AudioClip ThrowSpike;
        public AudioClip ThrowRock;
        public AudioClip ThrowOpbjext;
        public AudioClip ThrowBomb;
        public AudioClip Step;
        public AudioClip Spawn;
    };

    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        public bool isPlayer2 = false;
        public Transform respawnPoint;
        public Transform throwableGrabber;
        public float throwForce = 10.0f;
        public bool isDead = false;
        public float spawnWait = 3.0f;
        private GameObject throwable = null;

        public AudioClip Die;
        public AudioClip Jump;
        public AudioClip ThrowSpike;
        public AudioClip ThrowRock;
        public AudioClip ThrowOpbjext;
        public AudioClip ThrowBomb;
        public AudioClip Step;
        public AudioClip Spawn;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_Grab = false;
        private bool m_Grabbed = false;
        private float timer = 0.0f;
        private bool animStart = false;
        private bool jumpSound;

        AudioSource audio;

        private GameObject gamwe;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            audio = GetComponent<AudioSource>();
        }

        public void Footstep()
        {
            audio.PlayOneShot(Step);
        }



        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                if (isPlayer2)
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump Alt");

                }
                else
                {
                    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");

                }
            }
            if (m_Jump && !jumpSound)
            {
                jumpSound = true;
                audio.PlayOneShot(Jump);
            }

            if (m_Character.m_Grounded)
            {
                jumpSound = false;
            }

            if (isDead)
            {
                this.transform.parent = null;
                m_Character.canMove = false;

                if (!animStart)
                {
                    audio.PlayOneShot(Die);
                    m_Character.GetComponent<Animator>().SetBool("Die", true);
                    animStart = true;
                }
                this.GetComponent<Rigidbody2D>().simulated = false;
                timer += Time.deltaTime;

                if (timer >= spawnWait)
                {
                    timer = 0.0f;
                    isDead = false;
                    m_Character.GetComponent<Animator>().SetBool("Die", false);
                    this.GetComponent<Animator>().SetTrigger("respawn");
                    audio.PlayOneShot(Spawn);
                    this.transform.position = new Vector3(respawnPoint.position.x, respawnPoint.position.y, transform.position.z);
                    this.GetComponent<Rigidbody2D>().simulated = true;
                    animStart = false;
                }
            }

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.RightControl);
            float h = 0.0f;
            if (isPlayer2)
            {
                h = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            }
            else
            {
                h = CrossPlatformInputManager.GetAxisRaw("Horizontal Alt");
            }
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
