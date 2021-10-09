using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControls : MonoBehaviour
{
    public Animator animator;
    public GameObject camera;

    public Vector3 cameraLocationOffset;

    Vector3 cameraLocationDefault;
    

    // Start is called before the first frame update
    void Start()
    {
        cameraLocationDefault = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxis("Vertical");

        if (vert == 1)
        {
            animator.SetBool("isRunning", true);


        } else
        {
            animator.SetBool("isRunning", false);
        }
    }
}
