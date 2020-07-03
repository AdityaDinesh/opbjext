using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class endDisplay : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public Text p1;
    public Text p2;
    public Text wins;
    public Text score;
    public Text highScore;
    public Image img;
    private bool nextScreen=false;

    private int p1Score;
    private int p2Score;

    void Start()
    {
      

        p1.enabled = false;
        p2.enabled = false;
        wins.enabled = false;
        score.enabled = false;
        highScore.enabled = false;
        img.enabled = false;
    }

    private void Update()
    {
        p1Score = player1.GetComponent<score>().currentScore;
        p2Score = player2.GetComponent<score>().currentScore;
        if (nextScreen && Input.anyKey)
        {
            //load end scene
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    public void win(int player)
    {
        StartCoroutine("showScreen", player);
    }

    private IEnumerator showScreen(int p)
    {
        yield return new WaitForSeconds(0.4f);
        img.enabled = true;
        yield return new WaitForSeconds(0.4f);
        if (p == 1)
        {
            p1.enabled = true;
            int i = 5 - p1Score.ToString().Length;
            if (i <= 0)
            {
                score.text = p1Score.ToString();
            }
            else
            {
                score.text = ("00000".Substring(0, i)) + p1Score.ToString();
            }
            
        }
        else
        {
            p2.enabled = true;
            int i = 5 - p2Score.ToString().Length;
            if (i <= 0)
            {
                score.text = p2Score.ToString();
            }
            else
            {
                score.text = ("00000".Substring(0, i)) + p2Score.ToString();
            }

        }
        wins.enabled = true;
        yield return new WaitForSeconds(0.4f);
        score.enabled = true;
        yield return new WaitForSeconds(0.4f);
        highScore.enabled = true;
        nextScreen = true;
    }
}
