using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public GameObject player;

    public Animator animator;

    public GameObject spawnPoint;
    public GameObject PortalSpawn;
    public GameObject PortalSpawn2;

    public float Speed = 10f;
    public float forceX = 200;
    public float forceY = 200;
    public float jumpForce;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool LevelComplete;
    public Transform portalCheck;
    public LayerMask whatIsPortal;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isGrounded2;
    public LayerMask whatIsGround2;


    private int extraJumps;
    public int extraJumpsValue;

    public GameObject NextLevelDialog;
    Vector2 dialogPos;

    public GameObject FireballR;
    public GameObject FireballL;
    Vector2 fireballPos;
    public float fireRate = 2.5f;
    float nextFire = 0.0f;

    public Transform muzzle;
    public static bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isGrounded2 = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround2);
        LevelComplete = Physics2D.OverlapCircle(portalCheck.position, checkRadius, whatIsPortal);

        float Dirx = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Dirx * Speed, rb.velocity.y);

        if (facingRight == false && Dirx > 0) {
            Flip();
        } else if (facingRight == true && Dirx < 0) {
            Flip();
        }
        if (Dirx != 0 && isGrounded == true || isGrounded2 == true && Dirx != 0)
        {
            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }


    }

    void Update() {

        if (isGrounded == true || isGrounded2 == true) {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            fire();
        }

        if (LevelComplete == true) {
            dialogPos = transform.position;
            dialogPos += new Vector2(0f, 0f);
            Instantiate(NextLevelDialog, dialogPos, Quaternion.identity);
            if (facingRight == true) {
                player.transform.position = PortalSpawn.transform.position;
            } else {
                player.transform.position = PortalSpawn2.transform.position;
            }
        }

        if (isGrounded == false && isGrounded2 == false)
        {
            animator.SetBool("IsJumping", true);
        } else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) {
            rb.velocity = Vector2.up * jumpForce;
        }

    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    // movable - move with platform
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.layer == 15) {
            this.transform.parent = col.transform;
        }
        if (col.gameObject.layer == 12 || col.gameObject.layer == 17 || col.gameObject.layer == 9)
        {
            player.transform.position = spawnPoint.transform.position;
            Score.DeathCount++ ;
            playerDead = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.layer == 15){
            this.transform.parent = null;
        }
    }

        void fire (){
        if (facingRight == true) {
            Instantiate (FireballR, muzzle.position, Quaternion.identity);
        } else {
            Instantiate (FireballL, muzzle.position, Quaternion.identity);
        }
    }
}
