using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable_spikes : MonoBehaviour
{
    float dirY, moveSpeed = 3f;
    bool moveUp = true;
    public float Down = 20.5f;
    public float Up = 29.5f;

    void Update()
    {
        if (transform.position.y > Up)
        {
            moveUp = false;
        }

        if (transform.position.y < Down)
        {
            moveUp = true;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }

    }
}
