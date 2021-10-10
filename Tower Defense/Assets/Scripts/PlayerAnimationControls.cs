using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour
{
    Animator animator;
    public GameObject camera;

    public Vector3 forwardOffset;
    public Vector3 leftOffset;
    public Vector3 rightOffset;
    public Vector3 backOffset;

    public int animationTime;
    public float camStatus;

    Vector3 camDefault;

    Vector3 animationStatus = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        camDefault = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y, camera.transform.localPosition.z);
        forwardOffset += camDefault;
        leftOffset += camDefault;
        rightOffset += camDefault;
        backOffset += camDefault;
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        float horz = Input.GetAxisRaw("Horizontal");

        float statusZ = animationStatus.z;
        float statusX = animationStatus.x;

        if(vert > 0)
            animationStatus.z = positiveGraph(vert, statusZ, "Velocity Z");
        else
            animationStatus.z = negativeGraph(vert, statusZ, "Velocity Z");
        if(horz > 0)
            animationStatus.x = positiveGraph(horz, statusX, "Velocity X");
        else
            animationStatus.x = negativeGraph(horz, statusX, "Velocity X");

        if (animationStatus.z > camStatus)
        {
            camera.transform.localPosition = forwardOffset;
        }
        else if (animationStatus.x > camStatus)
        {
            camera.transform.localPosition = rightOffset;
        }
        else if (animationStatus.x < -camStatus)
        {
            camera.transform.localPosition = leftOffset;
        }
        else if (animationStatus.z < -camStatus)
        {
            camera.transform.localPosition = backOffset;
        }
        else
        {
            camera.transform.localPosition = camDefault;
        }
    }

    float positiveGraph(float direction, float status, string name)
    {
        if (direction == 1)
        {
            if (status < animationTime)
            {
                status += Time.deltaTime;
            }
        }
        else if (status > 0)
        {
            status -= 2.5f * Time.deltaTime;
        } else
        {
            status = 0;
        }

        animator.SetFloat(name, status);

        return status;
    }
    

    float negativeGraph(float direction, float status, string name)
    {
        if (direction == -1)
        {
            if (status > -animationTime)
            {
                status -= Time.deltaTime;
            }
        }
        else if (status < 0)
        {
            status += 2.5f * Time.deltaTime;
        } else
        {
            status = 0;
        }
        
        animator.SetFloat(name, status);

        return status;
    }
}
