using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Snowy snowy;
    public float timeOffset;
    public Vector3 posOffset;
    public Animator animator;

    private Vector3 velocity;
    private bool isDashing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isDashing = snowy.isDashing;
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
        animator.SetBool("isDashing", isDashing);

    }
}
