using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBuilder : MonoBehaviour
{
    
    public float buildRange;
    public bool inRange = false;
    public Transform location;
    public GameObject turret;
    private GameObject playerobj;
    Turret_TA targetingsystem;
    GameObject turretManagers;
    float distfromplayer;
    // Start is called before the first frame update
    void Start()
    {
        targetingsystem = GetComponent<Turret_TA>();
        playerobj = GameObject.Find("Player");
        turret.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        // if there's no rigid body we already know its not a player so be done
        if (other.attachedRigidbody == null)
            return;

        distfromplayer = Vector3.Distance(transform.position, playerobj.transform.position);

        if (other.attachedRigidbody.CompareTag("Player") && distfromplayer <= buildRange)
        {
            inRange = true;

            if (Input.GetKeyDown(KeyCode.B))
            {
                //Build the turret at this turret location
                turret.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            inRange = false;
    }
}
