using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private void flip()
    {
        Vector3 LocalScale = transform.localScale;
        LocalScale.x *= -1;
        transform.localScale = LocalScale;
    }
    bool isTurned = true;

    private float horizontal;
    public float speed;
    public float jumpingPower;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    Vector3 movement;

    private bool IsGrounded;
    public Animator Anim;

    ////

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;

    public bool KnockFromRight;

    private Transform oridginalParent; //dddddddddddddddddddddddddd

    private void Start()
    {
        oridginalParent = transform.parent;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

        if (movement.x > 0 && IsGrounded == true || movement.x < 0 && IsGrounded == true)
        {
            Anim.Play("Run");
        }
        else if (IsGrounded == false)
        {
            Anim.Play("Jump");
        }
        else
        {
            Anim.Play("Idle");
        }

        if (movement.x > 0 && isTurned == false)
        {
            flip();
            isTurned = true;
        }
        if (movement.x < 0 && isTurned == true)
        {
            flip();
            isTurned = false;
        }
        movement.x = Input.GetAxisRaw("Horizontal");

        Anim.SetBool("OnGround", IsGrounded);
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        Anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    private void FixedUpdate()
    {
        if (KBCounter <= 0)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);  //основной код передвижения
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCounter -= Time.deltaTime;
        }
    }    

    //ddddddddddddddddddddddddddddddddddd
    public void SetParent(Transform newParent)
    {
        oridginalParent = transform.parent;
        transform.parent = newParent;
    }
    public void ResetParent()
    {
        transform.parent = oridginalParent;
    }
}
