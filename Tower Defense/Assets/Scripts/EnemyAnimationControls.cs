using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationControls : MonoBehaviour
{
    public float deathTime;

    Animator animator;

    float waitingTime;
    float velocity;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        waitingTime = 0;
        velocity = 0;

        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = true;

            Collider col = rb.GetComponent<Collider>();
            col.isTrigger = true;
        }

        animator.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (waitingTime <= deathTime && waitingTime < deathTime + 1)
        {
            waitingTime += Time.deltaTime;
        }

        if (waitingTime > deathTime)
        {
            gameObject.GetComponentInParent<NavMeshAgent>().enabled = false;
            enableRagdoll();
        }

        animator.SetFloat("Velocity", velocity);

    }

    void enableRagdoll()
    {
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;

            Collider col = rb.GetComponent<Collider>();
            col.isTrigger = false;
        }

        animator.enabled = false;
    }
}
