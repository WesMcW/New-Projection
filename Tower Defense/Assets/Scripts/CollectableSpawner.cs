using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    public GameObject currency;

    public float spawnTimer;

    public static CollectableSpawner inst;

    void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawn()
    {
        Instantiate(currency, transform.position, Quaternion.identity);
    }

    public void timeDelay()
    {
        //Debug.Log("New Timer Generated");
        Invoke("spawn", Random.Range(20, 60));
    }
}
