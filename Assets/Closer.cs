using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closer : MonoBehaviour
{
    public float maxY, minY;
    public Transform Player;
    bool moveUp;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > maxY)
        {
            moveUp = false;
        }
        else if (transform.position.y < minY)
        {
            moveUp = true;
        }
        if ((Player.position.x - 5)< transform.position.x && moveUp == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Speed * Time.deltaTime);
        }
        else if ((Player.position.x - 5)> transform.position.x && moveUp == false)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
        }
    }
}
