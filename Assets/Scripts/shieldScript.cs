using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldScript : MonoBehaviour
{
    int speed = 500;
    public Transform ShieldPos;
    public static GameObject self;
    public GameObject Self;

    // Start is called before the first frame update
    void Start()
    {
        ShieldPos = drone.ShieldPos;
        self = Self;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, ShieldPos.position, speed * Time.deltaTime);
    }
}
