using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HenController : MonoBehaviour
{
    private Transform target;

    public GameObject hen; 

    private Rigidbody2D rb;

    private bool isShot;
    public Transform shotCheck;
    public float checkRadius;
    public LayerMask whatIsShot;

    public float nextJump = 0.0f;
    public float jumpRate = 2.5f;

    public float jumpForce;
    public float Speed;

    public bool FacingRight;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isShot = Physics2D.OverlapCircle(shotCheck.position, checkRadius, whatIsShot);

        if (target.position.x > transform.position.x)
        {
            //face right
            FacingRight = true;
        }
        else if (target.position.x < transform.position.x)
        {
            //face left
            FacingRight = false;
        }

        
    }


    // Update is called once per frame
    void Update()
    {
        if (FacingRight == true)
        {
            rb.velocity = new Vector2(1 * Speed, rb.velocity.y);
        }

        if (FacingRight == false)
        {
            rb.velocity = new Vector2(-1 * Speed, rb.velocity.y);
        }

        if (Time.time > nextJump)
        {
            rb.velocity = Vector2.up * jumpForce;
            nextJump = Time.time + jumpRate;
        }

        if (isShot == true)
        {
            Score.ScoreValue += 10;
            Destroy(hen);
        }
    }

}
