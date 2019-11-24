using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballL : MonoBehaviour
{
    public static float velX;
    float velY = 0f;
    Rigidbody2D rb3;

    // Start is called before the first frame update
    void Start()
    {
        rb3 = GetComponent<Rigidbody2D> ();
        velX = -35f;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb3.velocity = new Vector2 (velX, velY);

    }
}
