using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public int dmg = 1;
    public float bullet_velocity = 1;
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

    // Update is called once per frame
    void Update()
    {
        if (TTL > 0)
            TTL -= Time.deltaTime;
        else
            Destroy(gameObject);
    }
}
