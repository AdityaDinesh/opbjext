using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class throwBehaviour : MonoBehaviour
{
    public int score;
    public bool hurting = false;
    public bool isOpbjext = false;
    public float destroyOffset = 20.0f;
    public Transform thrower;
    private spikeTrap spike;
    private grenade gren;

    // Update is called once per frame
    void Start()
    {
        if (GetComponent<spikeTrap>() != null)
        {
            spike = GetComponent<spikeTrap>();
            gren = GetComponent<grenade>();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hurting)
        {
            if(collision.transform.CompareTag("Platform") || collision.transform.CompareTag("Wall"))
            {
                hurting = false;
            }

            if (collision.transform.tag == "Player" && collision.transform!=thrower && !isOpbjext && !GetComponent<grenade>() && !GetComponent<spikeTrap>())
            {
                if (GetComponent<Animator>())
                {
                    Animator rockAnim = GetComponent<Animator>();
                    if (rockAnim.GetCurrentAnimatorStateInfo(0).IsTag("Rock"))
                    {
                        rockAnim.SetTrigger("Break");
                    }
                }
                thrower.GetComponent<score>().addScore(score);
                collision.transform.GetComponent<Platformer2DUserControl>().isDead = true;
                hurting = false;
            }

            else
            {
                if (spike != null)
                {
                    Debug.Log("This bit");
                    spike.doSpikeThings();
                }
            }
        }
    }

    private void Update()
    {
        //if (isOpbjext && transform.parent != null)
        //{
        //    if (transform.parent.CompareTag("Player"))
        //    {
        //        if (transform.parent.GetComponent<Platformer2DUserControl>().isDead == true)
        //        {
        //            this.transform.parent = null;
        //            this.GetComponent<Rigidbody2D>().simulated = true;
        //            this.transform.position = transform.parent.position;
        //        }
        //    }
        //}
     
        if (!isOpbjext)
        {
            if (Mathf.Abs(this.transform.position.x - Camera.main.transform.position.x) > destroyOffset)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
