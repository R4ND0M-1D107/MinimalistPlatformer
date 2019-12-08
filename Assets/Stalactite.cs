﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalactite : MonoBehaviour
{
    public float Speed;
    private Transform target;
    bool Colliding;
    public GameObject Self;
    bool Under;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < 2)
        {
            Under = true;
        }
        if (Under == true)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Speed * Time.deltaTime);
            if (Colliding == true)
            {
                Destroy(Self);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Colliding = true;
    }
}
