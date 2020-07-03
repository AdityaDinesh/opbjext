using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crownScript : MonoBehaviour
{
   public Image p1Crown;
   public Image p2Crown;
   public Image noCrown;
    public Text p1Score;
    public Text p2Score;
    // Update is called once per frame

    private void Start()
    {
        p1Crown.enabled = false;
        p2Crown.enabled = false;
        noCrown.enabled = true;
    }
    void Update()
    {
        if (int.Parse(p1Score.text)> int.Parse(p2Score.text))
        {
            p1Crown.enabled = true;
            p2Crown.enabled = false;
            noCrown.enabled = false;
        }
        else if(int.Parse(p1Score.text) < int.Parse(p2Score.text))
        {
            p1Crown.enabled = false;
            p2Crown.enabled = true;
            noCrown.enabled = false;

        }
        else
        {
            p1Crown.enabled = false;
            p2Crown.enabled = false;
            noCrown.enabled = true;
        }
    }
}
