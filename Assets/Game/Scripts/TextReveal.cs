using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextReveal : MonoBehaviour
{

    private TextMeshPro m_TextMeshPro;


    IEnumerator Start()
    {
        m_TextMeshPro = gameObject.GetComponent<TextMeshPro>() ?? gameObject.AddComponent<TextMeshPro>();

        int totalVisibleCharacters = m_TextMeshPro.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            m_TextMeshPro.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
                yield return new WaitForSeconds(8.0f);

            counter += 1;

            yield return new WaitForSeconds(0.05f);
        }
    }



}
