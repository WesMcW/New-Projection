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
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");

        if (vert == 1)
        {
            if (animationStatus.z < animationTime)
            {
                animationStatus.z += Time.deltaTime;
            } 

            animator.SetFloat("Velocity Z", animationStatus.z);
        } 
        else
        {
            if (animationStatus.z > 0)
            {
                animationStatus.z -= 2.5f * Time.deltaTime;
            }
            else 

            animator.SetFloat("Velocity Z", animationStatus.z);
        }

        if (horz == 1)
        {
            if (animationStatus.x < animationTime)
            {
                animationStatus.x += Time.deltaTime;
            } 

            animator.SetFloat("Velocity X", animationStatus.x);
        } 
        else
        {
            if (animationStatus.x > 0)
            {
                animationStatus.x -= 2.5f * Time.deltaTime;
            } 

            animator.SetFloat("Velocity X", animationStatus.x);
        }

        if (vert == -1)
        {
            if (animationStatus.z > -animationTime)
            {
                animationStatus.z -= Time.deltaTime;
            }

            animator.SetFloat("Velocity Z", animationStatus.z);
        }
        else
        {
            if (animationStatus.z < 0)
            {
                animationStatus.z += 2.5f * Time.deltaTime;
            }

            animator.SetFloat("Velocity Z", animationStatus.z);
        }

        if (horz == -1)
        {
            if (animationStatus.x > -animationTime)
            {
                animationStatus.x -= Time.deltaTime;
            }

            animator.SetFloat("Velocity X", animationStatus.x);
        }
        else
        {
            if (animationStatus.x < 0)
            {
                animationStatus.x += 2.5f * Time.deltaTime;
            }

            animator.SetFloat("Velocity X", animationStatus.x);
        }

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
}
