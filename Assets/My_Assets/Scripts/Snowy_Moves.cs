using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowy_Moves : MonoBehaviour
{
    //Varaiables
    public float moveSpeed;
    public float jumpForce;

    //Cheker State
    private bool isJumping;
    private bool isGrouded;
    private bool isDashing;

    public Transform groundCheckLeft;
    public Transform groundCheckRight;

    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the player is grounded
        isGrouded = Physics2D.OverlapArea(groundCheckLeft.position, groundCheckRight.position);

        float horizontalMovement= Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrouded == true)
        {

            isJumping = true;

        }

        MovePlayer(horizontalMovement);
        
        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    // Controller
    void MovePlayer(float _horizontalMovement)
    {

        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        //Jump
        if(isJumping == true)
        {

            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;

        }
        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
            {
            StartCoroutine ("DashMove");
            }
    }

       IEnumerator DashMove()
        {
            
            if (isDashing == false)
            {
                isDashing = true;
                moveSpeed += 500;
                yield return new WaitForSeconds(.3f);
                moveSpeed -= 500;
                isDashing = false;
            }
             
        }
           
    

    //Make the sprite flip
    void Flip(float _velocity)
    {
        if(_velocity > 0.1f)
        {

            spriteRenderer.flipX = false;

        }else if(_velocity < -0.1f)
        {

            spriteRenderer.flipX = true;

        }
    }
}
