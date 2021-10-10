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
    EnemySpawner spawner;
    float secsplayed;

    private void Start()
    {  
        spawner = GameObject.Find("GlobalManagers").GetComponent<EnemySpawner>();
    }
    void Update()
    {
        secsplayed += Time.deltaTime;
        timer.text = String.Format("{0:0.##}", secsplayed);
        roundCount.text = spawner.roundCount.ToString();

        currencyCount.text = GetComponent<CollectableManager>().currencyAmount.ToString();
        roundCount.text = EnemySpawner.inst.roundCount.ToString();
    }
}
