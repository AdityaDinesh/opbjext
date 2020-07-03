using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class CameraFollow : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    private AudioSource audio;
    public AudioClip battle;
    public AudioClip runner;
    bool BattleMusic;

    private bool isLocked = false;
    private Transform cameraTarget;


    void Start() {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (player1.GetComponent<Platformer2DUserControl>().isDead)
        {
            cameraTarget = player2;
            isLocked = false;
        }

        else if (player2.GetComponent<Platformer2DUserControl>().isDead)
        {
            cameraTarget = player1;
            isLocked = false;
        }
        else
        {
            isLocked = true;
        }

        if (isLocked)
        {
            if (!BattleMusic) {
                audio.Stop();
                audio.clip = battle;
                audio.Play();
                BattleMusic = true;
            }
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }

        }

        else
        {
            if (BattleMusic)
            {
                audio.Stop();
                audio.clip = runner;
                audio.Play();
                BattleMusic = false;
            }
            transform.position = new Vector3(cameraTarget.position.x, transform.position.y, transform.position.z);
            foreach (Transform child in transform)
            {
                if(!child.CompareTag("Spawner"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
}
