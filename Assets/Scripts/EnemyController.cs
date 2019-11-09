using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

 public float speed;
 private Transform target;

 private bool isShot;

   public GameObject Enemy;

   public Transform shotCheck;
   public float checkRadius;
   public LayerMask whatIsShot;

 // Use this for initialization
 void Start () {
     target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
 }
 
 // Update is called once per frame
 void FixedUpdate () {
     isShot = Physics2D.OverlapCircle(shotCheck.position, checkRadius, whatIsShot);     

 }
 
 void Update () {
     if (isShot == true) {
         Score.ScoreValue +=5;
         Destroy(Enemy);
     }
    
     transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
     
 }
}
