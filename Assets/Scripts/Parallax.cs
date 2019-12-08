using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startpos, startpos2;
    public GameObject cam;
    public float parallaxEffect, parallaxEffect2;

    void Start()
    {
        startpos = transform.position.x;
        startpos2 = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);
        float dist2 = (cam.transform.position.y * parallaxEffect2);
        
        transform.position = new Vector3(startpos + dist, startpos2 + dist2, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}
