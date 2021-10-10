using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationControls : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void enableRagdoll()
    {
        transform.parent.tag = "Respawn";
        gameObject.GetComponentInParent<NavMeshAgent>().enabled = false;
        foreach (Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.isKinematic = false;

            Collider col = rb.GetComponent<Collider>();
            col.isTrigger = false;
        }

        animator.enabled = false;
    }
}
