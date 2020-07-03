using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeTrap : MonoBehaviour
{
    private throwBehaviour tb;
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        tb = GetComponent<throwBehaviour>();
    }

    // Update is called once per frame
    public void doSpikeThings()
    {
        Debug.Log("ThisOtherBti");
        spike.GetComponent<spikeHurt>().thrower = tb.thrower;
        spike.GetComponent<spikeHurt>().score = tb.score;
        Instantiate(spike, new Vector3(transform.position.x-1, transform.position.y, transform.position.z) , Quaternion.identity);
        Destroy(this.gameObject);
    }

}
