using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{

    public AudioClip Victory;
    AudioSource audio;
    public GameObject Goal;
    public SceneReference nextScene;
    private GameObject winCanvas;
    public int player;

    throwBehaviour tb;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        winCanvas = GameObject.Find("WinCanvas");
        tb = GetComponent<throwBehaviour>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == Goal.name)
        {
            tb.thrower.GetComponent<score>().addScore(tb.score);
            Camera.main.GetComponent<AudioSource>().Stop();
            audio.clip = Victory;
            audio.Play();
            endDisplay ed = winCanvas.GetComponent<endDisplay>();
            ed.win(player);
        }
    }

  
}
