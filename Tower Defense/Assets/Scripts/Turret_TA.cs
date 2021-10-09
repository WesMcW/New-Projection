using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_TA : MonoBehaviour
{
    // Will use the collider on the Managers object as a targeting range. Using 'OnCollision'.
    // Start is called before the first frame update
    BoxCollider targetingBox;
    public int count_inrange = 0;
    [SerializeField] List<GameObject> hostiles = new List<GameObject>(); // make this array of enemy components containing the data needed for the agent
    void Start()
    {
        targetingBox = GetComponent<BoxCollider>();
        
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log("Trigger Enter");

        //using on trigger because its not physical collider
        if (c.CompareTag("Enemy"))
        {
            //Debug.Log("Enemy detected in-range");
            int new_len = count_inrange++;
            // check if full OR empty
            hostiles.Add(c.gameObject);
        }
    }

    private void OnTriggerExit(Collider c)
    {
        Debug.Log("Trigger Exit");

        //using on trigger because its not physical collider
        if (c.CompareTag("Enemy"))
        {
            Debug.Log("Enemy detected leaving range");
            count_inrange--;
            int enemyidx = hostiles.IndexOf(c.gameObject);
            hostiles.RemoveAt(enemyidx);
            
        }
    }
    void SortHostilesByDistance(){
    }
    // Update is called once per frame
    void Update()
    {
    }
}
