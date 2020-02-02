using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDestroyer : MonoBehaviour
{
    public GameObject Explosion;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Destroy());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(Explosion);
    }
}
