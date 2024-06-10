using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmove : MonoBehaviour
{
    public float speed = 1f;
    public float jumpforce = 5f;
    public float movement = 0f;
    private bool facRight = true;

    private bool isground;
    public Transform feetpos;
    public float checkradius;
    public LayerMask whatisground;

    Rigidbody2D rb;
    SpriteRenderer sr;
    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * speed * Time.deltaTime;

        isground = Physics2D.OverlapCircle(feetpos.position, checkradius, whatisground);
        if(isground == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
        if(isground == true)
        {
            animator.SetBool("isjump", false);
        }
        else
        {
            animator.SetBool("isjump", true);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.05f)
            //rb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
    }

    void flip()
    {
        facRight = !facRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    private void FixedUpdate()
    {
        if(facRight == false && movement > 0)
        {
            flip();
        }
        else if(facRight == true && movement < 0)
        {
            flip();
        }

        if (movement == 0)
        {
            animator.SetBool("isrun", false);
        }

        else
        {
            animator.SetBool("isrun", true);
        }
    }
}