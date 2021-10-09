using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    public bool inRange = false;
    public Transform location;
    public GameObject turret;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inRange = true;

            if (Input.GetMouseButtonDown(0))
            {
                //Build the turret at this turret location
                gameObject.SetActive(false);
                Instantiate(turret, location.transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            inRange = false;
    }
}
