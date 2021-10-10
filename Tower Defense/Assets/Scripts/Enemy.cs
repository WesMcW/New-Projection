using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public int damage = 1;

    private NavMeshAgent agent;
    public Transform target;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Hub").transform;
        agent.SetDestination(target.transform.position);
    }

    private void Update()
    {
        if (health <= 0)
        {
            GetComponentInChildren<EnemyAnimationControls>().enableRagdoll();
            Invoke("Death", 2f);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag("Hub"))
        {
            c.gameObject.GetComponent<HubHealth>().hubHp -= damage;
            Destroy(gameObject);
        }
        if (c.gameObject.CompareTag("Bullet"))
        {
            health -= c.gameObject.GetComponent<Projectile>().dmg;
            Destroy(c.gameObject);
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
