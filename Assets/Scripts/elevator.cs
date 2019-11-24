using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float Down = 20.5f;
    public float Up = 29.5f;
    float dirY, moveSpeed = 7f;
    bool moveUp = true;
    bool coliding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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

        if (moveUp == true && coliding == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else if (moveUp == false && coliding == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.layer == 11)
        {
            coliding = true;
        } else
        {
            coliding = false;
        }
    }
}
