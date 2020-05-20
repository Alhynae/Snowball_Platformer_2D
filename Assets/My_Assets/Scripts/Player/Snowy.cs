using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Snowy : MonoBehaviour
{
    public Rigidbody2D rb;

    public HUD hud;
    public Animator animator;
    public Transform groundcheck;
    public Transform wallCheckL;
    public Transform wallCheckR;
    public float checkRadius;
    public LayerMask whatIsGround;

    //Sats
    public float baseSpeed;
    private float speed;
    public int growthState;
    public float health;
    public int damage;


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
    


    private void Start()
    {
        //Get the rigidbody
        this.rb = GetComponent<Rigidbody2D>();
        //Dash
        this.dashTime = startDashTime;
        this.dashSpeed = baseDashSpeed;
        //Jump
        this.jumpForce = baseJumpForce;
        this.extraJumps = extraJumpsValue;
        //Speed
        this.speed = baseSpeed;
    }

    private void Update()
    {
         //Check if the player is grounded
        this.isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
        this.isWallNearbyLeft = Physics2D.OverlapCircle(wallCheckL.position, checkRadius,whatIsGround);
        this.isWallNearbyRight = Physics2D.OverlapCircle(wallCheckR.position, checkRadius,whatIsGround);

        //Animation Sprite
        this.animator.SetFloat("Speed", Mathf.Abs(moveInput));
        this.animator.SetBool("isDashing", isDashing);

        /*if (this.rb.velocity.y == 0){
            this.animator.SetBool("isJumping", false);
            this.animator.SetBool("isFalling", false);
        } else if (this.rb.velocity.y < 0){
            this.animator.SetBool("isJumping", false);
            this.animator.SetBool("isFalling", true);
        } else if (this.rb.velocity.y > 0){
            this.animator.SetBool("isJumping", true);
            this.animator.SetBool("isFalling", false);
        }*/
        
        
        //Function
        Growth();
        PlayerMovements();
       
        //DEBUG
        hud.SetGrowth(health);

    }

    void PlayerMovements()
    {
        //Lateral Movement
        this.moveInput = Input.GetAxisRaw("Horizontal");
        this.rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (this.facingRight == false && this.moveInput > 0)
        {
            Flip();
        }
        else if (this.facingRight == true && this.moveInput < 0)
        {
            Flip();
        }

        //Flip the sprite
        void Flip()
        {
            this.facingRight = !this.facingRight;
            this.transform.Rotate(0f, 180f, 0f);
        }

         //Jump
        if (this.isGrounded == true)
        {
            this.extraJumps = this.extraJumpsValue;
        }

        if(Input.GetKeyDown(KeyCode.Space) && this.extraJumps > 0)
        {
            this.rb.velocity = Vector2.up * jumpForce;
            this.extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && this.extraJumps == 0 && this.isGrounded == true)
        {
            this.rb.velocity = Vector2.up * jumpForce;
        }

        //Walljump
        if (this.wallJumpAvailable == true)
        {
            if (this.isWallNearbyLeft)
            {
                this.isWallNearby = 1;
            } else if (this.isWallNearbyRight)
            {
                this.isWallNearby = -1;
            }
            if (Input.GetKeyDown(KeyCode.Space) && (this.isWallNearbyLeft || this.isWallNearbyRight))
            {
                this.wallJumping = true;
            }

            if (this.wallJumping == true)
            {
                this.rb.velocity = new Vector2(speed * this.isWallNearby, this.jumpForce);
                Invoke("SetWallJumpingToFalse", 0.08f);
            }
        }
        //Dash
        
        if (this.dashAvailable == true)
        {
            if (this.cooldownDashTimer > 0) //Cooldown
            {
                this.dashReady = 0;
                hud.SetDashIcon(dashReady);
                this.cooldownDashTimer -= Time.deltaTime;
            } else if (cooldownDashTimer < 0)
            {
                this.dashReady = 1;
                hud.SetDashIcon(dashReady);
                this.cooldownDashTimer = 0;
            }

            if (this.direction == 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift) && this.cooldownDashTimer == 0)
                {
                    this.cooldownDashTimer = cooldownDash;
                    if (this.moveInput < 0)
                    {
                        this.direction = 1;
                    }
                    else if (this.moveInput > 0)
                    {
                        this.direction = 2;
                    }
                }
            }
            else
            {
                if (this.dashTime <= 0)
                {
                    this.direction = 0;
                    this.dashTime = startDashTime;
                    this.rb.velocity = Vector2.zero;
                    this.isDashing = false;
                }
                else
                {
                    this.isDashing = true;
                    this.dashTime -= Time.deltaTime;

                    if (direction == 1)
                    {
                        this.rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        this.rb.velocity = Vector2.right * dashSpeed;
                    }
                }
            }
        }
    }

    void SetWallJumpingToFalse()
    {
        this.wallJumping = false;
    }

    void Growth()
    {
        if (this.health > 0)
        {
            
            if (this.health <= 30)
            {
                this.wallJumpAvailable = true;
                this.dashAvailable = true;
                this.dashSpeed = baseDashSpeed;
                this.speed = baseSpeed;
                this.jumpForce = baseJumpForce;
                this.extraJumpsValue = 1;
                this.hud.SetGrowth(growthState);
            }
            if (this.health > 30 && this.health <= 60)
            {
                this.wallJumpAvailable = true;
                this.dashAvailable = true;
                this.dashSpeed = baseDashSpeed - 1;
                this.speed = baseSpeed - 1;
                this.jumpForce = baseJumpForce - (int)0.5;
                this.extraJumpsValue = 1;
                this.hud.SetGrowth(growthState);
            }
            if (this.health > 60 && this.health <= 90)
            {
                this.wallJumpAvailable = false;
                this.dashAvailable = false;
                this.speed = baseSpeed - 2;
                this.jumpForce = baseJumpForce - (int)0.7;
                this.extraJumpsValue = 0;
                this.hud.SetGrowth(growthState);
            }

        } else
        {
            Death.PlayerDeath();
        }       

    }
}