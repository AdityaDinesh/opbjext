using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    void Awake()
    {
        int index = Random.Range(0, levels.Length);
        Instantiate(levels[index], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
