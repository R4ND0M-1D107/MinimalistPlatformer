using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroyerR : MonoBehaviour
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
    public Animator animator;


    void Start(){
        StartCoroutine (Destroy());
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
            FireballR.velX = 0F;
            animator.SetBool("Destroyed", true);
            Destroy(fireball, 0.667f);
        }
    }
    
    IEnumerator Destroy(){
        yield return new WaitForSeconds(2);
        FireballR.velX = 0f;
        animator.SetBool("Destroyed", true);
        Destroy(fireball, 0.667f);
    }
}
