﻿using System.Collections;
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

    private float Speed;
    public float MaxSpeed;
    public float BaseSpeed;
    public float acceleration;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float DropJumpMultiplier = 20f;

    public GameObject LandingAnim;
    public Transform Ground;

    private Rigidbody2D rb;

    public static bool facingRight = true;

    private bool LevelComplete;
    public Transform portalCheck;
    public LayerMask whatIsPortal;

    //public float attackRange = 0.5f;
    //public Transform attackPoint;
    //public LayerMask enemyLayers;

    private bool isGrounded;
    public float checkRadius;

    private int extraJumps = 1;

    public GameObject NextLevelDialog;
    Vector2 dialogPos;

    public GameObject FireballR;
    public GameObject FireballL;
    public GameObject PlayerLaser;
    public GameObject Pellet;
    public float FireballFireRate;
    public float LaserFireRate;
    public float PelletFireRate;
    float nextFireball = 0.0f;
    float nextLaser = 0.0f;
    float nextPellet = 0.0f;
    public static int laserAmmo;
    public static int fireballAmmo;
    public static int shotgunAmmo;
    int maxAmmo = 3;
    
    bool JumpsReset;
    public Transform muzzle;
    public static bool playerDead = false;
    public static float Health;
    public static float maxHealth = 5f;
    bool Immunity;
    public GameObject HaloRing;
    SpriteRenderer spriteRenderer;
    public GameObject shield;
    SpriteRenderer shieldSprite;
    PolygonCollider2D shieldCollider;
    public static float ShieldUses;
    public bool ShieldActive;

    public static bool takeDamage;

    public static int weaponNumber;

    void Start()
    {
        shotgunAmmo = laserAmmo = fireballAmmo = maxAmmo; 
        rb = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        Health = SkillHolder.maxHealth;
        spriteRenderer = HaloRing.GetComponent<SpriteRenderer>();
        shieldSprite = shield.GetComponent<SpriteRenderer>();
        shieldCollider = shield.GetComponent<PolygonCollider2D>();
        ShieldUses = SkillHolder.TimesPurchased;
    }

    void FixedUpdate()
    {
        LevelComplete = Physics2D.OverlapCircle(portalCheck.position, checkRadius, whatIsPortal);

        float Dirx = Input.GetAxis("Horizontal");

        if (Dirx != 0 && Speed < MaxSpeed && Input.GetKey(KeyCode.LeftShift))
        {
            Speed = (Speed + acceleration * Time.deltaTime);
        }
        else
        {
            Speed = BaseSpeed;
        }

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
        weaponNumber = Mathf.Clamp(weaponNumber, 1, 3);
        weaponNumber += (int) Input.GetAxis("Mouse ScrollWheel");
        Debug.Log("" + weaponNumber);

        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") ) {
            if (weaponNumber == 1 && Time.time > nextFireball && fireballAmmo > 0)
            {
                nextFireball = Time.time + FireballFireRate;
                fireballAmmo--;
                fire(1);
            }else if (weaponNumber == 2 && Time.time > nextLaser && laserAmmo > 0)
            {
                nextLaser = Time.time + LaserFireRate;
                laserAmmo--;
                fire(2);
            }else if (weaponNumber == 3 && Time.time > nextPellet && shotgunAmmo > 0)
            {
                nextPellet = Time.time + PelletFireRate;
                shotgunAmmo--;
                fire(3);
            }
            
        }
        

        if (Input.GetKey("q") && ShieldUses > 0 && ShieldActive == false)
        {
            ShieldActive = true;
            ShieldUses--;
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
            if (SkillHolder.DoubleJump == true)
            {
                extraJumps = 2;
            } else if (SkillHolder.DoubleJump == false)
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
        if (Health <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        GunScript.Rotation *= -1;
        GunScript.flipModifier *= -1;
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
            if (Immunity == false)
            {
                Vector3 temp = new Vector3(0, 15f, 0);
                Immunity = true;
                player.transform.position += temp;
                Health--;
                spriteRenderer.enabled = true;
                StartCoroutine(EndImumnity());
                takeDamage = true;
            }
        }
        if (col.gameObject.layer == 17) {
            if (Immunity == false)
            {
                Immunity = true;
                Health--;
                spriteRenderer.enabled = true;
                StartCoroutine(EndImumnity());
                takeDamage = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col) {
        if (col.gameObject.layer == 15) {
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
    void fire(int x) {
        if (x == 1)
        {
            if (facingRight == true)
            {
                Instantiate(FireballR, muzzle.position, Quaternion.Euler(0.0f, 0.0f, GunScript.Rotation));
            }
            else
            {
                Instantiate(FireballL, muzzle.position, Quaternion.Euler(0.0f, 0.0f, GunScript.Rotation));
            }
        }else if (x == 2)
        {
            Instantiate(PlayerLaser, muzzle.position, Quaternion.Euler(0.0f, 0.0f, GunScript.Rotation));
        }else if (x == 3)
        {
            for(int c = 1; c <= 5; c++)
            {
                Instantiate(Pellet, muzzle.position, Quaternion.Euler(0.0f, 0.0f, GunScript.Rotation));
            }
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
        ShieldActive = false;
    }
}
