using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnLocation;
    public int roundCount;
    public GameObject enemyInstance;
    public bool spawning = false;
    public bool canSpawn = false;
    public float timeBtwnEachGoon = 1f;
    public int maxGoonCount = 5;
    int goonCount = 0;

    void Start()
    {
        roundCount = 0;
        StartSpawning();
    }

    public void StartSpawning()
    {
        spawning = true;
        StartCoroutine("Spawning");
    }

    public IEnumerator Spawning()
    {
        DeployTheGoons();
        yield return new WaitForSeconds(timeBtwnEachGoon);

        if (canSpawn) StartCoroutine("Spawning");
    }

    public void DeployTheGoons()
    {
        if (goonCount < maxGoonCount)
        {
            Instantiate(enemyInstance, spawnLocation.position, Quaternion.identity);
            goonCount++;
        }

        if (goonCount == maxGoonCount)
        {
            canSpawn = false;
        }
    }
}
