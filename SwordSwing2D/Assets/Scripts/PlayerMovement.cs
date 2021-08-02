using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float jumpForce;
    public float speed;

    
    public float checkRadius;
    public LayerMask whatIsGround;
    private CapsuleCollider2D capsuleCollider2d;

    private Rigidbody2D rb;
    
    private Animator anim;
    private bool isGrounded;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider2d = transform.GetComponent<CapsuleCollider2D>();
    }


    private bool GroundCheck()
    {
        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(capsuleCollider2d.bounds.center, capsuleCollider2d.bounds.size - new Vector3(0.1f,0f,0f),  0f, Vector2.down, extraHeightText, whatIsGround);
        Debug.DrawRay(capsuleCollider2d.bounds.center + new Vector3(capsuleCollider2d.bounds.extents.x, 0), Vector2.down * (capsuleCollider2d.bounds.extents.y + extraHeightText));
        Debug.DrawRay(capsuleCollider2d.bounds.center - new Vector3(capsuleCollider2d.bounds.extents.x, 0), Vector2.down * (capsuleCollider2d.bounds.extents.y + extraHeightText));
        Debug.DrawRay(capsuleCollider2d.bounds.center - new Vector3(capsuleCollider2d.bounds.extents.x, capsuleCollider2d.bounds.extents.y + extraHeightText), Vector2.right * (capsuleCollider2d.bounds.extents.x));
        //Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }


    private void FixedUpdate()
    {

        if (GroundCheck() == true)
        {
            isGrounded = true;
        }
        else if (GroundCheck() == false)
        {
            isGrounded = false;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

        if (moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    private void Update()
    {
        anim.SetBool("Jumping", !isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded==true)
        {
            anim.SetBool("Jumping", true);
            rb.velocity = Vector2.up * jumpForce;

        }
       
        
    }
    

}