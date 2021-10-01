using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float moveSpeed;
    public float jumpForce;
    public bool isGrounded = false;
    public Transform groundCheck;
    public LayerMask groundLayer;

    float horizontalMove;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    bool jump = false;
    public bool isFalling = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !controller.isDead && !controller.isDoorOpen)
        {
            jump = true;
            AudioManager.instance.Play("Jump");
            Jump();
        }

        if (isFalling || jump && !isGrounded)
        {
            jump = false;
        }

        if (!isFalling)
        {
            AudioManager.instance.Play("Land");
        }

        if (animator.GetFloat("Speed") == 0)
        {
            AudioManager.instance.Play("FootSteps");
        }

        if (controller.isDead
            || controller.isHarmed
            || controller.isDoorOpen)
        {
            AudioManager.instance.StopPlay("FootSteps");
        }
    }

    void FixedUpdate()
    {
        if (!controller.isDead && !controller.isDoorOpen)
        {
            horizontalMove = Input.GetAxis("Horizontal");

            transform.Translate(horizontalMove * moveSpeed, 0, 0);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.5f, groundLayer);

        isFalling = rb.velocity.y < 0 && !isGrounded;

        Move();

        // If the input is moving the player right and the player is facing left...
        if (horizontalMove > 0 && !m_FacingRight)
        {
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (horizontalMove < 0 && m_FacingRight)
        {
            Flip();
        }

        //Walk animation
        if (isGrounded)
        {
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        //Jumping animation
        if (jump)
        {
            animator.SetBool("IsJump", true);
        }
        else 
        {
            animator.SetBool("IsJump", false);
        }

        //Fall animation
        if (isFalling)
        {
            animator.SetBool("IsFall", true);
        }
        else
        {
            animator.SetBool("IsFall", false);
        }

        //Dead animation
        if (controller.isDead)
        {
            animator.SetBool("IsDead", true);
        }
        else
        {
            animator.SetBool("IsDead", false);
        }

        //Check if door open (Celebrate animation)
        if (controller.isDoorOpen)
        {
            animator.SetBool("IsDoorOpen", true);
        } else
        {
            animator.SetBool("IsDoorOpen", false);
        }

        //Harmed animation
        if (controller.isHarmed)
        {
            animator.SetBool("IsHarmed", true);
        }
        else
        {
            animator.SetBool("IsHarmed", false);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveSpeed * horizontalMove, rb.velocity.y);
    }

    void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
