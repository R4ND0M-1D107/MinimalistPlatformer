using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireballscript : MonoBehaviour
{
    public float velX = 5f;
    float velY = 0f;
    Rigidbody2D rb3;
    
    // Start is called before the first frame update
    void Start()
    {
        rb3 = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb3.velocity = new Vector2 (velX, velY);

    }
}
