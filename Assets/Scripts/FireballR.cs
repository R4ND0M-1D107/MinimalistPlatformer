using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballR : MonoBehaviour
{
    public static float velX;
    float velY = 0f;
    Rigidbody2D rb3;
    public GameObject fireball;
    public GameObject Explosion;

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
        StartCoroutine(Destroy());
        rb3 = GetComponent<Rigidbody2D> ();
        velX = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        
        rb3.velocity = new Vector2 (velX, velY);

    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.25f);
        Instantiate(Explosion, transform.position, Quaternion.identity);
        Destroy(fireball);
    }
}
