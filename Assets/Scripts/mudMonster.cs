using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mudMonster : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float Speed;
    bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < minX)
        {
            moveRight = true;
        }

        if (transform.position.x > maxX)
        {
            moveRight = false;
        }
        if (moveRight == true)
        {
            transform.position = new Vector2(transform.position.x + Speed * Time.deltaTime, transform.position.y);
        }
        else if (moveRight == false)
        {
            transform.position = new Vector2(transform.position.x - Speed * Time.deltaTime, transform.position.y);
        }
    }
}
