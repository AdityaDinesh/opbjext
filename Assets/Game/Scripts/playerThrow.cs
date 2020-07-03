using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class playerThrow : MonoBehaviour
{
    public Vector3 grabArea;
    public Vector3 grabAreaOffset;
    public Vector3 itemHolderOffsetL;
    public Vector3 itemHolderOffsetR;
    public GameObject itemToGrab;
    public bool m_Grabbed = false;

    private bool charging = false;
    public float power = 0f;
    public float powerMultiplier;
    private int dir;
    private UnityStandardAssets._2D.PlatformerCharacter2D pc;
    private bool isPlayer2;


    //public Slider slider;
    void Start()
    {
        pc = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
        isPlayer2 = this.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().isPlayer2;
    }

    // Update is called once per frame
    void Update()
    {


        if (!m_Grabbed)
        {
            itemToGrab = null;
            Collider2D[] toGrab = Physics2D.OverlapBoxAll(transform.position + grabAreaOffset, grabArea, 1f);
            foreach (Collider2D grab in toGrab)
            {
                if (grab.transform.tag == "Throwable")
                {
                    itemToGrab = grab.gameObject;
                    break;
                }
            }
            if (itemToGrab != null && Input.GetButtonUp("Fire1") && !isPlayer2)
            {
                if(!itemToGrab.GetComponent<throwBehaviour>().isOpbjext)
                {
                     itemToGrab.GetComponent<Rigidbody2D>().simulated = false;
                }
                if(itemToGrab.GetComponent<throwBehaviour>().isOpbjext)
                {
                    itemToGrab.transform.position = itemToGrab.GetComponent<WinCondition>().Goal.transform.position;
                }
                else
                {
                    itemToGrab.transform.position = transform.position;
                }
                itemToGrab.transform.parent = this.transform;
                m_Grabbed = true;
            }
            if (itemToGrab != null && Input.GetButtonUp("Fire2") && isPlayer2)
            {
                if (!itemToGrab.GetComponent<throwBehaviour>().isOpbjext)
                {
                    itemToGrab.GetComponent<Rigidbody2D>().simulated = false;
                }
                itemToGrab.transform.position = transform.position;
                itemToGrab.transform.parent = this.transform;
                m_Grabbed = true;
            }
        }
        else
        {
            if(this.GetComponent<Platformer2DUserControl>().isDead)
            {
                if(itemToGrab.GetComponent<WinCondition>())
                {
                    itemToGrab.transform.parent = null;
                }
                else
                {
                    Destroy(itemToGrab);
                }
                m_Grabbed = false;
            }

            if (itemToGrab != null)
            {
                if (pc.m_FacingRight)
                {
                    itemToGrab.transform.localPosition = itemHolderOffsetL;
                }
                else
                {

                    itemToGrab.transform.localPosition = itemHolderOffsetR;
                }
            }

            if (Input.GetButtonDown("Fire1") && !isPlayer2)
            {
                charging = true;
            }

            if (Input.GetButtonDown("Fire2") && isPlayer2)
            {
                charging = true;
            }
           

            //Debug.Log(pc.m_FacingRight);

            if (Input.GetButtonUp("Fire1") && charging && !isPlayer2 && itemToGrab != null)
            {
                charging = false;
                itemToGrab.GetComponent<Rigidbody2D>().simulated = true;
                itemToGrab.transform.parent = null;
                if (pc.m_FacingRight)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;

                }
                itemToGrab.GetComponent<Rigidbody2D>().velocity = new Vector2(dir * power * powerMultiplier, transform.position.y + 5);

                throwBehaviour tb = itemToGrab.GetComponent<throwBehaviour>();
                tb.hurting = true;
                tb.thrower = this.transform;

                if (itemToGrab.GetComponent<grenade>() != null)
                {
                    grenade gren = itemToGrab.GetComponent<grenade>();
                    gren.StartCoroutine("timer");
                }
                m_Grabbed = false;
                power = 0f;
            }

            if (Input.GetButtonUp("Fire2") && charging && isPlayer2 && itemToGrab != null)
            {
                charging = false;
                itemToGrab.GetComponent<Rigidbody2D>().simulated = true;
                itemToGrab.transform.parent = null;
                if (pc.m_FacingRight)
                {
                    dir = 1;
                }
                else
                {
                    dir = -1;

                }
                itemToGrab.GetComponent<Rigidbody2D>().velocity = new Vector2(dir * power * powerMultiplier, transform.position.y + 5);

                throwBehaviour tb = itemToGrab.GetComponent<throwBehaviour>();
                tb.hurting = true;
                tb.thrower = this.transform;

                if (itemToGrab.GetComponent<grenade>() != null)
                {
                    grenade gren = itemToGrab.GetComponent<grenade>();
                    gren.StartCoroutine("timer");
                }
                m_Grabbed = false;
                power = 0f;
            }

            if (charging)
            {
                if (power <= 10f)
                {
                    power += 0.1f;
                }
                else
                {
                    power = 10f;
                }
            }

        }


        ////////slider display bit - prolly delete this at some point////////
        //slider.value = power;
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + grabAreaOffset, grabArea);
    }

}
