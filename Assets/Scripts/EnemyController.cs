using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    private Transform target;
    private bool NeverDone;

    public float speed;

    private bool isShot;

    public GameObject Enemy;

    public Transform shotCheck;
    public float checkRadius;
    public LayerMask whatIsShot;
    public AudioSource audioSource;

    private bool Stalk;



    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        NeverDone = true;
        Stalk = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isShot = Physics2D.OverlapCircle(shotCheck.position, checkRadius, whatIsShot);

        if (target.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }
        else if (target.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }

    }

    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) > 20)
        {
            Stalk = false;
        } else if (Mathf.Abs(target.position.x - transform.position.x) <= 20)
        {
            if (isShot == true)
            {
                if (NeverDone == true)
                {
                    NeverDone = false;
                    Stalk = false;
                    audioSource.Play();
                    Score.ScoreValue += 5;
                    Destroy(Enemy, audioSource.clip.length);
                } 

            }
            else
            {
                Stalk = true;
            }
        }
        StalkPlayer();
        
    }

    void StalkPlayer()
    {
        if (Stalk == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}