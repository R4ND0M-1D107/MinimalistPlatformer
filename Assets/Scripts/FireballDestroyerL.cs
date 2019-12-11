using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroyerL : MonoBehaviour
{
    
    public GameObject fireball;

    private bool isColliding;
    private bool isColliding2;
    private bool isColliding3;
    public Transform colCheck;
    public float checkRadius;
    public LayerMask enemyLayer;
    public LayerMask movableLayer;
    public LayerMask groundLayer;
    public GameObject Explosion;
    public Transform fireballPos;


    void Start(){
       
    }

    void FixedUpdate()
    {
        isColliding = Physics2D.OverlapCircle(colCheck.position, checkRadius, enemyLayer);
        isColliding2 = Physics2D.OverlapCircle(colCheck.position, checkRadius, movableLayer);
        isColliding3 = Physics2D.OverlapCircle(colCheck.position, checkRadius, groundLayer);
    }
 
    void Update()
    {
        if(isColliding == true || isColliding2 == true || isColliding3 == true)
        {
            Instantiate(Explosion, fireballPos.position, Quaternion.identity);
            Destroy(fireball);
        }
    }
    
    IEnumerator Destroy(){
        yield return new WaitForSeconds(0.4f);
        Instantiate(Explosion, fireballPos.position, Quaternion.identity);
        Destroy(fireball);
    }
}
