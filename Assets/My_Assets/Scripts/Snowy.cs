using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowy : MonoBehaviour
{
    private Rigidbody2D rb;
    //Sats
    public float speed;
    public int maxGrowthState = 3;
    private int growthState;

    public SnowyHUD snowyHUD;

    //Ground / Inputcheck
    private float moveInput;
    private bool isGrounded;
    public Transform feetPosL;
    public Transform feetPosR;
    public Animator animator;

    //Jump
    private float jumpTimeCounter;
    public float jumpForce;
    public float jumpTime;
    private bool isJumping;
    private bool facingRight = true;

    //Dash
    public float dashSpeed = 30f;
    public float startDashTime = 0.1f;
    public int dashReady;

    public float cooldownDash = 2f;
    private float cooldownDashTimer;
    private float dashTime;
    private int direction;
    public bool isDashing;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        growthState = maxGrowthState;
        snowyHUD.SetMaxGrowth(maxGrowthState);
    }

    private void Update()
    {
         //Check if the player is grounded
        isGrounded = Physics2D.OverlapArea(feetPosL.position, feetPosL.position);

        //Animation Sprite
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isDashing", isDashing);
        
        //Function
        PlayerMovements();
        //DEBUG

        if (Input.GetKeyDown(KeyCode.G))
        {
            TakeDamage(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            Healed(1);
        }

    }

    void PlayerMovements()
    {

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
        }

        //Jump
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }

        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        //Lateral Movement
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        //Flip the sprite
        void Flip()
        {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }

        //Dash
        
        if (cooldownDashTimer > 0) //Cooldown
        {
            dashReady = 0;
            snowyHUD.SetDashIcon(dashReady);
            cooldownDashTimer -= Time.deltaTime;
        } else if (cooldownDashTimer < 0)
        {
            dashReady = 1;
            snowyHUD.SetDashIcon(dashReady);
            cooldownDashTimer = 0;
        }

        if (direction == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && cooldownDashTimer == 0)
            {
                cooldownDashTimer = cooldownDash;
                if (moveInput < 0)
                {
                    direction = 1;
                }
                else if (moveInput > 0)
                {
                    direction = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
                isDashing = false;
            }
            else
            {
                isDashing = true;
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }

    }

    void Growth()
    {

        if (growthState > 0)
        {
            
            if (growthState == 1)
            {

            }
            if (growthState == 2)
            {

            }
            if (growthState == 3)
            {

            }

        } else {

            //DEATH

        }       

    }

    void TakeDamage(int damage)
    {
        growthState -= damage;
        snowyHUD.SetGrowth(growthState);
    }

    void Healed(int healed)
    {
        growthState += healed;
        snowyHUD.SetGrowth(growthState);
    }
}