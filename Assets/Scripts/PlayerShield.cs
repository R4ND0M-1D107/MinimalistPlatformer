using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public Transform target;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, 500 * Time.deltaTime);
        if (player.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(-2.25f, 2.25f, 1);
        }
        else if (player.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(2.25f, 2.25f, 1);
        }
    }
}
