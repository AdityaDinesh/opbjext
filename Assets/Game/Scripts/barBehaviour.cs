using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barBehaviour : MonoBehaviour
{
    public playerThrow pt;
    public Sprite[] sprites;
    private Image img;
    private float p;
    // Update is called once per frame
    private void Start()
    {
        img = GetComponent<Image>();
    }
    void Update()
    {
        p= pt.power;
        if (p>=1.9f)
        {
            img.sprite = sprites[4];

        }
        else if (p>=1.4f)
        {
            img.sprite = sprites[3];

        }
        else if (p >= 0.8f)
        {
            img.sprite = sprites[2];

        }
        else if (p >= 0.1f)
        {
            img.sprite = sprites[1];

        }
        else
        {
           img.sprite=sprites[0];
        }
    }
}
