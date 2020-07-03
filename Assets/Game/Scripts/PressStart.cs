using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressStart : MonoBehaviour {

    Animator textAnim;
    public AudioSource audio;
    public AudioClip startSound;
    public SceneReference gameScene;
    public float delayTime = 3.0f;

    void Start()
    {
        textAnim = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetButtonDown("Submit")) {
            textAnim.SetTrigger("PressStart");
            audio.PlayOneShot(startSound);
            StartCoroutine(Delay());
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(gameScene);
    }
}
