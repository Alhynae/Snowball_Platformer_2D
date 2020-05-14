using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Snowy : MonoBehaviour
{
    private Rigidbody2D rb;
    public SnowyHUD snowyHUD;
    public Animator animator;
    public Transform groundcheck;
    public Transform wallCheckL;
    public Transform wallCheckR;
    public float checkRadius;
    public LayerMask whatIsGround;
    private Transform playerSpawn;
    
    //Sats
    public float baseSpeed;
    private float speed;
    private int maxGrowthState = 3;
    public int growthState;

    //Checker
    private float moveInput;
    private bool isGrounded;
    private bool isWallNearbyLeft;
    private bool isWallNearbyRight;
    private float isWallNearby;
   
    private bool facingRight = true;
   
    //Jump
    public int baseJumpForce;
    private int jumpForce;
    public int extraJumpsValue;
    private int extraJumps;
    //WallJump
    private bool wallJumpAvailable;
    private bool wallJumping;

    //Dash
    private bool dashAvailable;
    public bool isDashing;
    private int dashReady;
    public float baseDashSpeed = 30f;
    private float dashSpeed;
    public float startDashTime = 0.1f;
    private float dashTime;
    private int direction;
   
    public float cooldownDash = 2f;
    private float cooldownDashTimer;
    
    //Cold_Heat
    public float zoneTimer;
    public float actualZoneTimer;

    private void Start()
    {
        Time.timeScale = 1f;

        playerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        //Get the rigidbody
        rb = GetComponent<Rigidbody2D>();
        //Initializing
        growthState = 1;
        //HUD
        snowyHUD.SetMaxGrowth(maxGrowthState);
        snowyHUD.SetGrowth(growthState);
        //Dash
        dashTime = startDashTime;
        dashSpeed = baseDashSpeed;
        //Jump
        jumpForce = baseJumpForce;
        extraJumps = extraJumpsValue;
        //Speed
        speed = baseSpeed;
        //ColdHeat
        actualZoneTimer = zoneTimer;
    }

    private void Update()
    {
         //Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
        isWallNearbyLeft = Physics2D.OverlapCircle(wallCheckL.position, checkRadius,whatIsGround);
        isWallNearbyRight = Physics2D.OverlapCircle(wallCheckR.position, checkRadius,whatIsGround);

        //Animation Sprite
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isDashing", isDashing);
        
        //Function
        Growth();
        PlayerMovements();
       
        //DEBUG

    }

    void PlayerMovements()
    {
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

         //Jump
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        //Walljump
        if (wallJumpAvailable == true)
        {
            if (isWallNearbyLeft)
            {
                isWallNearby = 1;
            } else if (isWallNearbyRight)
            {
                isWallNearby = -1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && (isWallNearbyLeft || isWallNearbyRight))
            {
                wallJumping = true;
            }

            if (wallJumping == true)
            {
                rb.velocity = new Vector2(speed * isWallNearby, jumpForce);
                Invoke("SetWallJumpingToFalse", 0.08f);
            }
        }
        //Dash
        
        if (dashAvailable == true)
        {
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
    }

    void SetWallJumpingToFalse()
    {
        wallJumping = false;
    }

    void Growth()
    {

        if (growthState > 0)
        {
            
            if (growthState == 1)
            {
                wallJumpAvailable = true;
                dashAvailable = true;
                dashSpeed = baseDashSpeed;
                speed = baseSpeed;
                jumpForce = baseJumpForce;
                extraJumpsValue = 1;
                snowyHUD.SetGrowth(growthState);
            }
            if (growthState == 2)
            {
                wallJumpAvailable = true;
                dashAvailable = true;
                dashSpeed = baseDashSpeed - 1;
                speed = baseSpeed - 1;
                jumpForce = baseJumpForce - (int)0.5;
                extraJumpsValue = 1;
                snowyHUD.SetGrowth(growthState);
            }
            if (growthState == 3)
            {
                wallJumpAvailable = false;
                dashAvailable = false;
                speed = baseSpeed - 2;
                jumpForce = baseJumpForce - (int)0.7;
                extraJumpsValue = 0;
                snowyHUD.SetGrowth(growthState);
            }

        } else {

            snowyHUD.SetGrowth(growthState);
            //Death();
            rb.position = playerSpawn.position;
            growthState = 1;

        }       

    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Collision
    private void OnTriggerStay2D(Collider2D collision){

        //HeatColdZonez
        if ( collision.CompareTag("Cold"))
        {
           if (actualZoneTimer > 0) //Cooldown
            {
                actualZoneTimer -= Time.deltaTime;
            } 
            else if (actualZoneTimer < 0)
            {
                actualZoneTimer = 0;
                growthState ++;
            }
        } else if ( collision.CompareTag("Heat"))
            {
                if (actualZoneTimer > 0) //Cooldown
                {
                    actualZoneTimer -= Time.deltaTime;
                } 
                else if (actualZoneTimer < 0)
                {
                    actualZoneTimer = 0;
                    growthState --;
            }
        } else if ( collision.CompareTag("ResetTimer")){
            actualZoneTimer = zoneTimer;
        }
    
    }
}