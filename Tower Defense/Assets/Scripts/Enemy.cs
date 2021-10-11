using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;

    public bool dead = false;

    private NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Hub").transform;
        agent.SetDestination(target.transform.position);
    }
    private void OnEnable()
    {
        // for each round above round 5 start adding HP in a linear way
        if (EnemySpawner.globalRoundCount >= 5)
        {
            int howfarfromfive = EnemySpawner.globalRoundCount - 5;
            for (int i = 0; i < howfarfromfive; i++)
            {
                health += 2; // adds 2 hp for each round above 5
            }
        }

    }
    private void Update()
    {
        if (health <= 0)
        {
            //EnemySpawner.inst.goonsKilled++;
            GetComponentInChildren<EnemyAnimationControls>().enableRagdoll();
            if (!dead)
            {
                EnemySpawner.inst.goonsKilled += 1;
                dead = true;
            }
            Invoke("Death", 2f);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Bullet"))
        {
            health -= c.gameObject.GetComponent<Projectile>().dmg;
            Destroy(c.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hub"))
        {
            other.gameObject.GetComponent<HubHealth>().hubHp -= damage;
            EnemySpawner.inst.goonsKilled += 1;
            Destroy(gameObject);
        }
    }

    public void Death()
    {
        //EnemySpawner.inst.goonsKilled += 1;
        Destroy(gameObject);
    }
}
