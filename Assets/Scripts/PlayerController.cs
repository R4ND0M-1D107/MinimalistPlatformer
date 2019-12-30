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
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float DropJumpMultiplier = 20f;

    public GameObject LandingAnim;
    public Transform Ground;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool LevelComplete;
    public Transform portalCheck;
    public LayerMask whatIsPortal;

    public float attackRange = 0.5f;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    private bool isGrounded;
    public float checkRadius;

    private int extraJumps = 1;

    public GameObject NextLevelDialog;
    Vector2 dialogPos;

    public GameObject FireballR;
    public GameObject FireballL;
    public float fireRate = 2.5f;
    float nextFire = 0.0f;
    bool JumpsReset;
    public Transform muzzle;
    public static bool playerDead = false;
    public static int Health;
    public static int maxHealth = 5;
    bool Immunity;
    public GameObject HaloRing;
    SpriteRenderer spriteRenderer;
    public GameObject shield;
    SpriteRenderer shieldSprite;
    PolygonCollider2D shieldCollider;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        Health = maxHealth;
        spriteRenderer = HaloRing.GetComponent<SpriteRenderer>();
        shieldSprite = shield.GetComponent<SpriteRenderer>();
        shieldCollider = shield.GetComponent<PolygonCollider2D>();
        
    }
   
    void FixedUpdate()
    {
        LevelComplete = Physics2D.OverlapCircle(portalCheck.position, checkRadius, whatIsPortal);

        float Dirx = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(Dirx * Speed, rb.velocity.y);

        if (facingRight == false && Dirx > 0) {
            Flip();
            
        } else if (facingRight == true && Dirx < 0) {
            Flip();
        }
        if (Dirx != 0 && isGrounded == true)
        {
            animator.SetBool("IsWalking", true);
        } else
        {
            animator.SetBool("IsWalking", false);
        }


    }

    void Update() {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
        
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire) {

            nextFire = Time.time + fireRate;
            fire();
        }
        if (Input.GetKey("c") && isGrounded == false && SkillHolder.DropJump == true)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (DropJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetKey("q") && SkillHolder.Shield == true)
        {
            shieldCollider.enabled = true;
            shieldSprite.enabled = true;
            StartCoroutine(EndShield());
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

        if (JumpsReset == false)
        {
            if(SkillHolder.DoubleJump == true)
            {
                extraJumps = 2;
            }else if(SkillHolder.DoubleJump == false)
            {
                extraJumps = 1;
            }
            
            JumpsReset = true;
        }
        if (isGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        } else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0) {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        if(Health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
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
        if (Input.GetKey("c"))
        {
            Instantiate(LandingAnim, Ground.position, Quaternion.identity);
        }
        if (col.gameObject.layer == 8)
        {
            isGrounded = true;
            JumpsReset = false;
            
        }
        if (col.gameObject.layer == 15) {
            this.transform.parent = col.transform;
            isGrounded = true;
            JumpsReset = false;
        }
        if (col.gameObject.layer == 9)
        {
            /*player.transform.position = spawnPoint.transform.position;
            Score.DeathCount++ ;
            playerDead = true;
            */
            if (Immunity == false)
            {
                Vector3 temp = new Vector3(0, 15f, 0);
                Immunity = true;
                player.transform.position += temp;
                Health--;
                spriteRenderer.enabled = true;
                StartCoroutine(EndImumnity());
            }
        }
        if (col.gameObject.layer == 17) {
            if (Immunity == false)
            {
                Immunity = true;
                Health--;
                spriteRenderer.enabled = true;
                StartCoroutine(EndImumnity());
            }
        }
    }
    
    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.layer == 15){
            this.transform.parent = null;
            isGrounded = false;
        }
        if (col.gameObject.layer == 8)
        {
            isGrounded = false;
        }
    }
    /*
    void Slash()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<damageScript>().TakeDamage();
        }
    }
    */
    void fire (){
        if (facingRight == true) {
            Instantiate (FireballR, muzzle.position, Quaternion.identity);
        } else {
            Instantiate (FireballL, muzzle.position, Quaternion.identity);
        }
    }
    IEnumerator EndImumnity()
    {
        yield return new WaitForSeconds(2);
        Immunity = false;
        spriteRenderer.enabled = false;
    }
    IEnumerator EndShield()
    {
        yield return new WaitForSeconds(3);
        shieldCollider.enabled = false;
        shieldSprite.enabled = false;
    }
}
