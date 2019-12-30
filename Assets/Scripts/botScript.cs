using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botScript : MonoBehaviour
{
    public Transform muzzle;
    public float speed;
    public GameObject projectile;
    Rigidbody2D rb;
    public Transform target;
    public Transform SelfPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < 20 && Mathf.Abs(target.position.x - transform.position.x) > 15)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (Mathf.Abs(target.position.x - transform.position.x) < 15)
        {
            Shooting();
        }
    }
    void Fire()
    {
        Instantiate(projectile, muzzle.position, Quaternion.identity);
    }
    IEnumerator Shooting()
    {
        Fire();
        yield return new WaitForSeconds(1.5f);
    }
}
