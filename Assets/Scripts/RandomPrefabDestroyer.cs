using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPrefabDestroyer : MonoBehaviour
{
    public GameObject self;
    public Transform Self;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Self.position.x - player.position.x < -50)
        {
            Destroy(self);
        }
    }
}
