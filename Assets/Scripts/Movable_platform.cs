using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_platform : MonoBehaviour
{

    float dirX, moveSpeed =5f;
    bool moveRight = true;
    public float left = 20.5f;
    public float right = 29.5f;
    float positionX;

    private void Start()
    {
        positionX = Creator.PositionX;
    }
    void Update()
    {
        if (transform.position.x > (right + positionX- 37.4)) {
            moveRight = false;
        }
        
        if (transform.position.x < (left + positionX - 37.4)) {
            moveRight = true;
        }
       
        if (moveRight) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        } else {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
        
    }

}
