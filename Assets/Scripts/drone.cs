using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drone : MonoBehaviour
{
    Animator animator;
    public GameObject shot;
    public GameObject shield;
    public GameObject Numbers;
    GameObject Shield;
    public GameObject self;
    public Transform muzzle;
    public Transform ShieldPos1;
    public static Transform ShieldPos;
    public static int shotCount;
    public float Speed, Speed2, Up, Down;
    bool moveUp, shoot;
    bool wasShot;
    bool ShootingDone;
    bool work;
    bool shieldActive;
    public Transform movePoint;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        ShieldPos = ShieldPos1;
        shotCount = 0;
        animator = Numbers.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        Speed2 = Speed + 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePoint.position, Speed2 * Time.deltaTime);
        if (wasShot == true)
        {
            shotCount++;
            animator.SetInteger("ShotCount1", shotCount);
            wasShot = false;
        }else if (PlayerController.playerDead == true)
        {
            shotCount = 0;
            animator.SetInteger("ShotCount1", shotCount);
            PlayerController.playerDead = false;
        }
        if(shotCount == 0 || shotCount == 1 || shotCount == 2)
        {
            //Phase1
            if (shieldActive == true)
            {
                Shield = shieldScript.self;
                Destroy(Shield);
                shieldActive = false;
            }
            if (movePoint.position.y > Up && moveUp == true)
            {
                moveUp = false;
                shoot = true;
            }else if (movePoint.position.y < Down && moveUp == false)
            {
                moveUp = true;
                shoot = true;
            }

            if (moveUp == true)
            {
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y + Speed * Time.deltaTime);
            }
            if (moveUp == false)
            {
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y - Speed * Time.deltaTime);
            }
            if (shoot == true)
            {
                Fire();
                shoot = false;
            }
        }
        else if (shotCount == 3 || shotCount == 4 || shotCount == 5)
        {
            //Phase2
            ShootingDone = true;
            if (transform.position.y > Up && work == true && moveUp == true)
            {
                work = false;
                moveUp = false;
                ShootingDone = false;
                StartCoroutine(Shooting1());
            }
            else if (transform.position.y < Down && work == true && moveUp == false)
            {
                work = false;
                moveUp = true;
                ShootingDone = false;
                StartCoroutine(Shooting1());
            }

            if (moveUp == true && ShootingDone == true)
            {
                work = true;
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y + Speed * Time.deltaTime);
            }
            if (moveUp == false && ShootingDone == true)
            {
                work = true;
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y - Speed * Time.deltaTime);
            }
        }
        else if (shotCount == 6 || shotCount == 7 || shotCount == 8)
        {
            //Phase3
            ShootingDone = true;
            if (transform.position.y > Up && work == true && moveUp == true)
            {
                work = false;
                moveUp = false;
                ShootingDone = false;
                StartCoroutine(Shooting2());
            }
            else if (transform.position.y < Down && work == true && moveUp == false)
            {
                work = false;
                moveUp = true;
                ShootingDone = false;
                StartCoroutine(Shooting2());
            }

            if (moveUp == true && ShootingDone == true)
            {
                work = true;
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y + Speed * Time.deltaTime);
            }
            if (moveUp == false && ShootingDone == true)
            {
                work = true;
                movePoint.position = new Vector2(movePoint.position.x, movePoint.position.y - Speed * Time.deltaTime);
            }
        }else if (shotCount == 9)
        {
            Death();
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 13 || collision.gameObject.layer == 18)
        {
            
        }
        else
        {
            wasShot = true;
        }
    }
    void Fire()
    {
        Instantiate(shot, muzzle.position, Quaternion.identity);
    }
    void ShieldCreate()
    {
        Instantiate(shield, ShieldPos.position, Quaternion.identity);
    }
    void Death()
    {
        Destroy(self);
    }
    IEnumerator Shooting1()
    {
        if (ShootingDone == false)
        {
            Fire();
            yield return new WaitForSeconds(0.15f);
            Fire();
            yield return new WaitForSeconds(0.15f);
            Fire();
            yield return new WaitForSeconds(0.15f);
            ShootingDone = true;
        }
    }
    IEnumerator Shooting2()
    {
        if (ShootingDone == false) {
            Shield = shieldScript.self;
            Destroy(Shield);
            shieldActive = false;
            Fire();
            yield return new WaitForSeconds(0.15f);
            Fire();
            yield return new WaitForSeconds(0.15f);
            Fire();
            yield return new WaitForSeconds(0.15f);
            ShootingDone = true;
            shieldActive = true;
            ShieldCreate();
        }
    }
}
