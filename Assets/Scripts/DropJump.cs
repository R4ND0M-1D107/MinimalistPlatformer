using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropJump : MonoBehaviour
{
    public GameObject self;
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
        yield return new WaitForSeconds(0.3f);
        Destroy(self);
    }
}
