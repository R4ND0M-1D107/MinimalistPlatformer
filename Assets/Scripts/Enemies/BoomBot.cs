using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBot : MonoBehaviour
{
    private Transform target;
    public float speed;
    public GameObject Self;
    public Transform Self2;
    public GameObject Shrapnel;
    private bool NeverDone;
    AudioSource SD;
    bool SelfDestroy;
    public Transform PlayerCheck;
    public float PlayerCheckRadius;
    public LayerMask whatIsPlayer;
    bool Stalk;
    public float stalkRadius;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        NeverDone = true;
        SD = GetComponent<AudioSource>();
        SelfDestroy = Physics2D.OverlapCircle(PlayerCheck.position, PlayerCheckRadius, whatIsPlayer);
        Stalk = Physics2D.OverlapCircle(PlayerCheck.position, stalkRadius, whatIsPlayer);

    }

    private void FixedUpdate()
    {
        if (target.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        else if (target.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1f, 1f, 1);
        }
    }

    // Update is called once per frame    
    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < 3 && (Mathf.Abs(target.position.y - transform.position.y) < 3) && NeverDone == true)
        {
            SelfDestruct();
            NeverDone = false;
        }
        if (Mathf.Abs(target.position.x - transform.position.x) < 20)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 17)
        {
            SelfDestruct();
        }
        else if(collision.gameObject.layer == 13)
        {
            SelfDestruct();
            Score.ScoreValue += 70;
        }
        else if(collision.gameObject.layer == 19)
        {
            SelfDestruct();
        }
    }
    void SelfDestruct()
    {
        for (int i = 1; i < 7; i++)
        {
            Instantiate(Shrapnel, Self2.position, Quaternion.identity);
        }
        Destroy(Self);
    }
}
