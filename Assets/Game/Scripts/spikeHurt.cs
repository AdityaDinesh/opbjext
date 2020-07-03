using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class spikeHurt : MonoBehaviour
{
    public GameObject spikeThrow;
    private PlatformerCharacter2D pc;
    private Animator anim;
    public int score;

    [HideInInspector]
    public Transform thrower;
    public bool trapped = false;

    private GameObject trappedPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(trappedPlayer != null)
        {
            if(trappedPlayer.GetComponent<Platformer2DUserControl>().isDead)
            {
                trapped = false;
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && !trapped)
        {
            trappedPlayer = collision.gameObject;
            trapped = true;
            Debug.Log("trapPlayer");
            anim.SetBool("trapped", true);
            pc = collision.gameObject.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
            pc.canMove = false;
            pc.currentSpike = this.gameObject;
        }
    }

    public void Break()
    {
        thrower.GetComponent<score>().addScore(score);
        Debug.Log("Breakk");
        anim.SetBool("break", true);
        Invoke("dest", 0.1f);
    }

    private void dest()
    {
        Destroy(this.gameObject);

    }
}
