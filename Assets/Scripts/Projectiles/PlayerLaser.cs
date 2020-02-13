using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb3;
    public GameObject self;
    Vector2 rotation;
    public Transform Muzzle;
    public Transform RotationModifier;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 11)
        {

        }
        else
        {
            Destroy(self);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Muzzle = GameObject.FindGameObjectWithTag("Muzzle").GetComponent<Transform>();
        RotationModifier = GameObject.FindGameObjectWithTag("VectorMod").GetComponent<Transform>();
        StartCoroutine(Destroy());
        rb3 = GetComponent<Rigidbody2D>();
        rotation = Muzzle.position - RotationModifier.position;
    }

    // Update is called once per frame
    void Update()
    {

        rb3.velocity = rotation * Speed;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.35f);
        Destroy(self);
    }

}
