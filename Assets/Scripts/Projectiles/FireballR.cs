using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballR : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rb3;
    public GameObject fireball;
    public GameObject Explosion;
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
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(fireball);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        Muzzle = GameObject.FindGameObjectWithTag("Muzzle").GetComponent<Transform>();
        RotationModifier = GameObject.FindGameObjectWithTag("VectorMod").GetComponent<Transform>();
        StartCoroutine(Destroy());
        rb3 = GetComponent<Rigidbody2D> ();
        rotation = Muzzle.position - RotationModifier.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb3.velocity = rotation * Speed;

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(fireball);
    }
}
