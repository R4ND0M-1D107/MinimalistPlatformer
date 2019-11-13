using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroyer : MonoBehaviour
{
    
    public GameObject fireball;
    public Transform explosionPrefab;

    private bool isColliding;
    private bool isColliding2;
    private bool isColliding3;
    public Transform colCheck;
    public float checkRadius;
    public LayerMask enemyLayer;
    public LayerMask movableLayer;
    public LayerMask groundLayer;


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
            Destroy(fireball);
        }
    }
    
    IEnumerator Destroy(){
        yield return new WaitForSeconds(2);
        Destroy(fireball);
    }
}
