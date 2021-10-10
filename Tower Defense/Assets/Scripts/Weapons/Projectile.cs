using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg = 1;
    public float bullet_velocity = 50f;
    public float TTL = 3f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    
    int GetDamage()
    {
        return dmg;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * bullet_velocity;

        if (TTL > 0)
            TTL -= Time.fixedDeltaTime;
        else
            Destroy(gameObject);
    }
}
