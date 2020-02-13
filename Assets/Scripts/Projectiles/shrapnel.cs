using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shrapnel : MonoBehaviour
{
    Rigidbody2D rb;
    float velX;
    float velY;
    public GameObject self;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velX = Random.Range(-1f, 1f);
        velY = Random.Range(-1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX * speed, velY * speed);
        Destroy(self, 0.6f);
    }


}
