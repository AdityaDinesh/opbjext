using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int targetScore;
    public Text sText;

    [HideInInspector]
    public int currentScore=0000;
    

    void Update()
    {
        if (currentScore < targetScore)
        {
            currentScore++;
            
        }else if(currentScore > targetScore && currentScore!=0)
        {
            currentScore--;

        }

        int i = 5 - currentScore.ToString().Length;
        if (i <= 0)
        {
            sText.text = currentScore.ToString();
        }
        else
        {
            sText.text = ("00000".Substring(0, i)) + currentScore.ToString();

        }
    }

    public void addScore(int a)
    {
        targetScore += a;   
    }
}
