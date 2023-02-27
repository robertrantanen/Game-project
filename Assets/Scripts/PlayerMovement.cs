using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    Animator animator;
    public float movementSpeed = 3f;
    public float jumpingForce = 5f;

    public Transform groundCheck;
    public LayerMask ground;

    public AudioSource jumpSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontal * movementSpeed, rb.velocity.y, vertical * movementSpeed);

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (moveDirection != new Vector3(0f, 0f, 0f))
        {
            animator.SetBool("Run", true);
            transform.rotation = Quaternion.LookRotation(moveDirection);
        } else
        {
            animator.SetBool("Run", false);
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        } 

        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        } else
        {
            animator.SetBool("Jump", true);
        }

    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpingForce, rb.velocity.z);
        jumpSound.Play();
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, 0.15f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jumpSound.Play();
        }
        if (collision.gameObject.CompareTag("Enemy head 2"))
        {
            Destroy(collision.transform.parent.parent.parent.gameObject);
            jumpSound.Play();
        }
        if (collision.gameObject.name == "JumpPad")
        {
            rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z);
            jumpSound.Play();
        }
    }


}
