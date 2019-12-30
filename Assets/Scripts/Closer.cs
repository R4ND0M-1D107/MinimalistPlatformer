using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closer : MonoBehaviour
{
    public float maxY, minY;
    public Transform Player;
    bool moveUp, moveDown;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        moveDown = true;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Player.position.x - 5)< transform.position.x && transform.position.y < maxY)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * 3 * Time.deltaTime);
        }
        else if ((Player.position.x - 5)> transform.position.x && moveDown == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            moveDown = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            moveDown = true;
        }
    }
}
