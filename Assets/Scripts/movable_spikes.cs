using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movable_spikes : MonoBehaviour
{
    float dirY, moveSpeed = 2.5f;
    bool moveUp = true;
    public float Up = 0;
    AudioSource Fall;
    Rigidbody2D rb;
    public GameObject spikePart;

    private void Start()
    {
        Fall = GetComponent<AudioSource>();
        rb = spikePart.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.y > Up)
        {
            moveUp = false;
        }

        if (moveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * 6 * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Fall.Play();
        moveUp = true;
    }
}
