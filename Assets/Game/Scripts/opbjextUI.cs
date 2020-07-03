using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class opbjextUI : MonoBehaviour
{
    private Image opbImage;
    public Sprite[] sprites;
    public GameObject cam;
    private SpriteRenderer sr;
    public bool yellow;
    private GameObject opb;
    void Start()
    {
        opbImage = GetComponent<Image>();

        if (yellow)
        {
            opb = GameObject.Find("Opbjext2");
        }
        else
        {
            opb = GameObject.Find("Opbjext1");
        }
        sr = opb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sr.isVisible)
        {
            //  Debug.Log("onScreen");
            opbImage.sprite = sprites[2];
        }
        else
        {
            if (opb.transform.position.x > cam.transform.position.x)
            {
                ///on right///
                opbImage.sprite = sprites[0];

            }
            else
            {
                ///on left///
                opbImage.sprite = sprites[1];
            }
        }
    }
}
