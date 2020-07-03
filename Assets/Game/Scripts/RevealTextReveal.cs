using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RevealTextReveal : MonoBehaviour
{
    public GameObject fucker;
    public SceneReference mainMenu;

    public string[] dialogues;
    public int rando;
    
    // Start is called before the first frame update
    void Start()
    {
        fucker.GetComponent<TextMeshPro>().color = Color.black;
        rando = Random.Range(0, dialogues.Length - 1);
        fucker.GetComponent<TextReveal>().enabled = false;
        fucker.GetComponent<TextMeshPro>().enabled = false;
        Invoke("TMPEnable", 1.9f);
        Invoke("PleaseEnable", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(mainMenu);
        }
    }

    void TMPEnable()
    {
        fucker.GetComponent<TextMeshPro>().enabled = true;
        fucker.GetComponent<TextMeshPro>().text = dialogues[rando];
    }

    void PleaseEnable()
    {
        fucker.GetComponent<TextMeshPro>().color = Color.white;
        fucker.GetComponent<TextReveal>().enabled = true;
    }
}
