using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    float velY, velX;
    Rigidbody2D rb;
    public float speed;
    public GameObject self;
    float mod;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velY = Random.Range(-0.45f, 0.45f);
        velX = Mathf.Sqrt(1 - Mathf.Pow(velY, 2));
        if (PlayerController.facingRight == true)
        {
            mod = 1;  
        }else
        {
            mod = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velX * speed * mod, velY * speed * mod);
        Destroy(self, 0.2f);
    }
}
