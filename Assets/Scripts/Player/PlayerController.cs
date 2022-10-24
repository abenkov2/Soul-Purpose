using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("moveParam")]
    [SerializeField] float hurtForce = 1f;
    [SerializeField] float jumpTime = 1f;
    [SerializeField] float fallAddition = 2.5f; 
    [SerializeField] float jumpAddition = 1.5f; 
    [SerializeField] float speed = 2f;
    [SerializeField] float jumpForce = 20f;
    [SerializeField] float extraHeight = 0.02f;
    float moveX;
    float moveY;
    int movement;

    [Header("check")]
    bool isFacingRight;
    bool jumpHold;  //������Ծ
    bool canMove;
    bool isOnGround;

    [Header("ref")]
    [SerializeField] Collider2D collider;
    [SerializeField] LayerMask groundLayerMask;
    Animator animator;
    Rigidbody2D rb;


    [Header("attackParam")]
    [SerializeField] float slashIntervalTime = 0.2f; 
    [SerializeField] int slashCount = 0;
    [SerializeField] float lastComboTime = 0.4f;
    [SerializeField] int slashDamage = 1;
    [SerializeField] float downRecoilForce;
    [SerializeField] float recoilForce;
    float lastSlash;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<Collider2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Flip();
        Jump();
        IsOnGround();
    }
    private void FixedUpdate()
    {
        JumpOptimize();
    }

    void Movement()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        }
        /* animation change*/
        if (moveX > 0)
        {
            movement = 1;
            isFacingRight = true;
        }
        else if (moveX < 0)
        {
            movement = -1;
            isFacingRight = false;
        }
        else
            movement = 0;
        animator.SetInteger("movement", movement);
    }
    void JumpCancel()
    {
        jumpTime = 1f;
        animator.ResetTrigger("jump");
    }
    void Flip()
    {
        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveX < 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
    }
    void Jump()
    {
        jumpHold = Input.GetButton("Jump");
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rb.velocity = Vector2.up * jumpForce / 2;
            jumpHold = true;
            animator.SetTrigger("jump");
        }
    }
    void IsOnGround()
    {
        isOnGround = collider.IsTouchingLayers(groundLayerMask); 
        animator.SetBool("isOnGround", isOnGround);
    }
    void JumpOptimize()
    {
        if (rb.velocity.y < 0)   
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * fallAddition * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !jumpHold) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * jumpAddition * Time.deltaTime;
        }
    }
}
