using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

   public GameObject player;

   public GameObject spawnPoint;

   public float Speed = 10f;
   public float jumpForce;
   
   private Rigidbody2D rb;

   private bool facingRight = true;

   private bool isGrounded;
   public Transform groundCheck;
   public float checkRadius;
   public LayerMask whatIsGround;

   private int extraJumps;
   public int extraJumpsValue;
   
    private bool isSpiked;
    public Transform spikeCheck;
    public LayerMask whatIsSpikes;

    private bool isKilled;
    public Transform killCheck;
    public LayerMask whatIsKill;

    public GameObject FireballR;
    public GameObject FireballL;
    Vector2 fireballPos;
    public float fireRate = 0.5f;
    float nextFire = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {
       extraJumps = extraJumpsValue;
        rb = GetComponent <Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isSpiked = Physics2D.OverlapCircle(spikeCheck.position, checkRadius, whatIsSpikes);
        isKilled = Physics2D.OverlapCircle(killCheck.position, checkRadius, whatIsKill);
        
        float Dirx = Input.GetAxis("Horizontal") ;
        Debug.Log(Dirx);
        rb.velocity = new Vector2(Dirx * Speed, rb.velocity.y);

        if(facingRight == false && Dirx > 0) {
            Flip();
        } else if(facingRight == true && Dirx < 0) {
            Flip();
        }
    }

    void Update(){
        if(isSpiked == true){
            player.transform.position = spawnPoint.transform.position;
            Score.ScoreValue -= 5;
        }
        
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
        }

        if(isKilled == true){
            player.transform.position = spawnPoint.transform.position;
            Score.ScoreValue -= 5;
        }

        if (Input.GetButtonDown ("Fire1") && Time.time > nextFire){

            nextFire = Time.time + fireRate;
            fire ();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0){
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip(){
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void fire (){
        fireballPos = transform.position;
        if (facingRight == true) {
            fireballPos += new Vector2 (+1f, -0.43f);
            Instantiate (FireballR, fireballPos, Quaternion.identity);
        } else {
            fireballPos += new Vector2 (-1f, -0.43f);
            Instantiate (FireballL, fireballPos, Quaternion.identity);
        }
    }

}
