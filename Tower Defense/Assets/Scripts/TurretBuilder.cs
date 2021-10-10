using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuilder : MonoBehaviour
{
    [SerializeField] Text buyText;
    public float buildRange;
    public bool inRange = false;
    public Transform location;
    public GameObject turret;
    private GameObject playerobj;
    Turret_TA targetingsystem;
    GameObject turretManagers;
    float distfromplayer;
    public int cost;

    // Start is called before the first frame update
    void Start()
    {
        targetingsystem = GetComponent<Turret_TA>();
        playerobj = GameObject.Find("Player");
        turret.gameObject.SetActive(false);
        buyText.text = String.Format("Buy {0} for {1}", targetingsystem.weapon.stats.name, cost*2);
    }

    // Update is called once per frame
    void FixedUpdate()
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

            if (Input.GetKeyDown(KeyCode.B) && other.gameObject.GetComponent<CollectableManager>().currencyAmount >= cost)
            {
                //Build the turret at this turret location
                turret.gameObject.SetActive(true);
                other.gameObject.GetComponent<CollectableManager>().currencyAmount -= cost;
                buyText.text = String.Format("{0}, {1} dmg", targetingsystem.weapon.stats.name, targetingsystem.weapon.dps);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            inRange = false;
    }
}
