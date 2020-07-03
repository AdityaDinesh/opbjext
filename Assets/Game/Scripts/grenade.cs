using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class grenade : MonoBehaviour
{
    public float delay;
    public float expRadius;
    public Vector3 offset;

    public AudioClip throwBomb;
    public AudioClip explosion;
    public new AudioSource audio;

    public Animator bombAnim;

    private throwBehaviour tb;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        bombAnim = GetComponent<Animator>();
        tb = GetComponent<throwBehaviour>();
    }

    public void doExplode()
    {
        bombAnim.SetTrigger("Explode");
        audio.PlayOneShot(explosion);
        Debug.Log("Bang");
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position+offset, expRadius);
        foreach(Collider2D hit in hits)
        {
            if (hit.tag == "Player")
            {
                tb.thrower.GetComponent<score>().addScore(tb.score);
                hit.gameObject.GetComponent<Platformer2DUserControl>().isDead = true;
            }
            else if(hit.tag != "Platform" && hit.tag != "Wall" && hit.GetComponent<WinCondition>() == null && hit.gameObject != this.gameObject)
            {
                if(!hit.GetComponent<spikeHurt>())
                {
                    Destroy(hit.gameObject);
                }
            }
        }
    }

    public IEnumerator timer()
    {
        bombAnim.SetTrigger("Thrown");
        audio.PlayOneShot(throwBomb);
        yield return new WaitForSeconds(delay);
        doExplode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + offset, expRadius);
    }
}
