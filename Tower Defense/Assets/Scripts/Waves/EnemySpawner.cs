using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawnLocation = new List<Transform>();
    public int roundCount;
    public GameObject enemyInstance;
    public bool spawning = false;
    public bool canSpawn = false;
    public float timeBtwnEachGoon = 1f;
    public float timeBtwnRound = 5f;
    public int maxGoonCount = 5;
    public int goonCount = 0;
    public int goonsKilled = 0;

    public static EnemySpawner inst;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        canSpawn = true;
        StartSpawning();
    }

    private void Update()
    {
        if (goonsKilled == maxGoonCount)
            StartCoroutine("NewRound");
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

        if (spawning) StartCoroutine("Spawning");
    }

    public void DeployTheGoons()
    {
        int rand = Random.Range(0, spawnLocation.Count);

        if (goonCount < maxGoonCount)
        {
            Instantiate(enemyInstance, spawnLocation[rand].position, Quaternion.identity);
            goonCount++;
        }

        if (goonCount == maxGoonCount)
        {
            StopCoroutine("Spawning");
            spawning = false;
            goonCount = 0;
            //canSpawn = false;
        }
    }

    public IEnumerator NewRound()
    {
        maxGoonCount += roundCount * 2;
        goonsKilled = 0;
        yield return new WaitForSeconds(timeBtwnRound);
        roundCount++;
        StartSpawning();
    }
}
