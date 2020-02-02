using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downProjectile : MonoBehaviour
{
    public static float velX = 0f;
    float Speed = 10;
    Rigidbody2D rb3;
    public GameObject self;

    void Start()
    {
        StartCoroutine(Destroy());
        rb3 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);

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
