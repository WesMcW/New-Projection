using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour
{
    public Animator animator;
    public GameObject camera;

    public Vector3 camOffset;
    public int animationTime;
    public float camStatus;

    Vector3 camDefault;

    float animationStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
        camDefault = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y, camera.transform.localPosition.z);
        camOffset += camDefault;
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");

        if (vert == 1)
        {
            if (animationStatus < animationTime)
            {
                animationStatus += Time.deltaTime;
            } else if (animationStatus > animationTime)
            {
                animationStatus = animationTime;
            }

            animator.SetFloat("Blend", animationStatus);
        } else
        {
            if (animationStatus > 0)
            {
                animationStatus -= 2.5f * Time.deltaTime;
            }
            else if (animationStatus < 0)
            {
                animationStatus = 0;
            }

            animator.SetFloat("Blend", animationStatus);
        }

        if (animationStatus > camStatus)
        {
            camera.transform.localPosition = camOffset;
        } else
        {
            camera.transform.localPosition = camDefault;
        }
    }
}
