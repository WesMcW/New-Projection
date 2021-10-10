using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] Text timer;
    [SerializeField] Text roundCount;
    [SerializeField] Text currencyCount;
    [SerializeField] GameObject turretsDisplay;
    EnemySpawner spawner;
    float secsplayed;

    const int NUM_TURRETS = 9;

    GameObject[] turrets = new GameObject[NUM_TURRETS];

    public float turretDisplayRange = 0;

    private void Start()
    {
        spawner = GameObject.Find("GlobalManagers").GetComponent<EnemySpawner>();
        turrets = GameObject.FindGameObjectsWithTag("Turret");
    }
    void Update()
    {
        secsplayed += Time.deltaTime;
        timer.text = String.Format("{0:0.##}", secsplayed);
        roundCount.text = spawner.roundCount.ToString();

        currencyCount.text = GetComponent<CollectableManager>().currencyAmount.ToString();
        roundCount.text = EnemySpawner.inst.roundCount.ToString();

        displayTurretPurchase();
    }

    GameObject findClosestTurret(GameObject[] turrets)
    {
        float? distFromPlayer = null;
        GameObject closeTurret;

        closeTurret = turrets[0];

        foreach (GameObject turret in turrets)
        {
            float distance = Vector3.Distance(transform.position, turret.transform.position);


            if (distFromPlayer == null)
            {
                distFromPlayer = distance;
            }
            else if (distance < distFromPlayer)
            {
                distFromPlayer = distance;
                closeTurret = turret;
                //Debug.Log("Updated Close Turret");
            }
        }
        //Debug.Log(distFromPlayer);
        return closeTurret;
    }

    void displayTurretPurchase()
    {
        GameObject nearbyTurret = findClosestTurret(turrets);

        bool built = nearbyTurret.GetComponentInChildren<TurretBuilder>().turret.active;

        int cost = nearbyTurret.GetComponentInChildren<TurretBuilder>().cost;
        int resources = GetComponent<CollectableManager>().currencyAmount;

        float turretDistance = Vector3.Distance(transform.position, nearbyTurret.transform.position);

        if (turretDistance < turretDisplayRange && !built && cost < resources)
        {
            turretsDisplay.SetActive(true);
        }
        else
        {
            turretsDisplay.SetActive(false);
        }
    }
}
