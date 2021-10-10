using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Transform p;
    private void Start()
    {
        p = GameObject.Find("Main Camera").transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(p);
    }
}
