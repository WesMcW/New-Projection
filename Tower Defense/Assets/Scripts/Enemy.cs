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
        agent.SetDestination(target.transform.position);
    }

    private void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hub"))
        {
            other.gameObject.GetComponent<HubHealth>().hubHp -= damage;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            //health -= other.gameObject.GetComponent<Projectile>().damage;
            Destroy(other.gameObject);
        }
    }


}
