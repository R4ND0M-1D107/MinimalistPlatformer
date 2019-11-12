using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

 public float speed;
 private Transform target;

 private bool isShot;

 AudioSource audioSource;
 public AudioClip Scream;

   public GameObject Enemy;

   public Transform shotCheck;
   public float checkRadius;
   public LayerMask whatIsShot;

 // Use this for initialization
 void Start () {
     target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
     audioSource = GetComponent<AudioSource>();
 }
 
 // Update is called once per frame
 void FixedUpdate () {
     isShot = Physics2D.OverlapCircle(shotCheck.position, checkRadius, whatIsShot);     

 }

 void Update () {
     if (isShot == true) {
         audioSource.PlayOneShot(Scream, 0.7F);
         Score.ScoreValue +=5;
         if(audioSource.isPlaying){
             Destroy(Enemy);
         }    
     }
    
     transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
     
 }
}
