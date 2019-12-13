using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{
    public float Down = 20.5f;
    public float Up = 29.5f;
    float dirY, moveSpeed = 7f;
    bool coliding = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Up  && coliding == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else if (transform.position.y > Down  && coliding == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == 11)
        {
            coliding = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.layer == 11)
        {
            coliding = false;
        }
    }
}
