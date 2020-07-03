using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class ObjectSpawner : MonoBehaviour
{
    public Transform player1;
    public Transform player2;
    public GameObject[] throwables;
    public float count = 3.0f;
    public float maxCount = 10.0f;
    public float spawnWait;
    public float timeIncrementIndex = 2.0f;
    public float spawnOffset = 5.0f;


    private float timer = 0.0f;
    private Vector3 offset = Vector3.zero;
    private float initialTime;
    private float counter = 0.0f;
    private GameObject[] waste;

    private bool startSpawn = true;

    void Start()
    {
        offset.x = spawnOffset;
        initialTime = spawnWait;
    }

    void Update()
    {
        timer += Time.deltaTime;
        waste = GameObject.FindGameObjectsWithTag("Throwable");

        if (waste.Length >= maxCount)
        {
            startSpawn = false;
        }
        else
        {
            startSpawn = true;
        }

        if(timer >= spawnWait && startSpawn)
        {
            for(int i=0; i < count; i++)
            {
                counter++;
                int index = Random.Range(0, throwables.Length);
                float x = Random.Range(transform.position.x, transform.position.x + offset.x);
                if(throwables[index] != null)
                {
                    Instantiate(throwables[index], new Vector3(x, transform.position.y, transform.position.z), transform.rotation);
                }
            }
            timer = 0;
            offset.x = spawnOffset;
            spawnWait += timeIncrementIndex;
        }

        if(player1.GetComponent<Platformer2DUserControl>().isDead || player2.GetComponent<Platformer2DUserControl>().isDead)
        {
            spawnWait = initialTime;
            timer = 0;
        }
    }
}
