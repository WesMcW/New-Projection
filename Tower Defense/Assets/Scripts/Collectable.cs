using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public int addAmount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.GetComponent<CollectableManager>())
            {
                CollectableSpawner.inst.timeDelay();
                collision.gameObject.GetComponent<CollectableManager>().currencyAmount += addAmount;
                Destroy(gameObject);
            }
           
        }
    }
}
