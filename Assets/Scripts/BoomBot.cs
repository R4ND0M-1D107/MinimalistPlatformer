using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomBot : MonoBehaviour
{
    private Transform target;
    public float speed;
    public GameObject Self;
    public Transform Self2;
    public GameObject Shrapnel;
    private bool NeverDone;
    AudioSource SD;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        NeverDone = true;
        SD = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if (target.position.x > transform.position.x)
        {
            //face right
            transform.localScale = new Vector3(1f, 1f, 1);
        }
        else if (target.position.x < transform.position.x)
        {
            //face left
            transform.localScale = new Vector3(-1f, 1f, 1);
        }
    }

    // Update is called once per frame    
    void Update()
    {
        if (Mathf.Abs(target.position.x - transform.position.x) < 2 && Mathf.Abs(target.position.y - transform.position.y) < 2 && NeverDone == true)
        {
            StartCoroutine(Death());
            NeverDone = false;
        }
        if (Mathf.Abs(target.position.x - transform.position.x) < 20)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private IEnumerator Death() {
        SD.Play();
        yield return new WaitForSeconds(1.5f);
        for (int i = 1; i < 7; i++) {
            Instantiate(Shrapnel, Self2.position, Quaternion.identity);
        }
        Destroy(Self);
    }
}
