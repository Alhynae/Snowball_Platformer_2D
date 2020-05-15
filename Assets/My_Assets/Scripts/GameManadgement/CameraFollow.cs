using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Snowy snowy;
    public float timeOffset;
    public Vector3 posOffset;
    public Animator animator;

    private Vector3 velocity;
    private bool isDashing;    

    void Update()
    {
        isDashing = snowy.isDashing;
        transform.position = Vector3.SmoothDamp(transform.position, snowy.transform.position + posOffset, ref velocity, timeOffset);
        animator.SetBool("isDashing", isDashing);

    }
}
