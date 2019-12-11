using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneProjectile : MonoBehaviour
{
    public static float velX;
    float velY = 0f;
    Rigidbody2D rb3;
    public GameObject self;

    void Start()
    {
        StartCoroutine(Destroy());
        rb3 = GetComponent<Rigidbody2D>();
        velX = -7f;
    }

    void Update()
    {

        rb3.velocity = new Vector2(velX, velY);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(self);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(self);
    }
}


