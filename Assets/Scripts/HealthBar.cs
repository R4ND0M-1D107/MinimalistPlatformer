using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Target;
    float scale;
    Transform bar;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + new Vector3(-14, 8, 1);
        if(PlayerController.Health == 5)
        {
            bar.localScale = new Vector3(1f, 1f);
        }else if(PlayerController.Health == 4)
        {
            bar.localScale = new Vector3(0.8f, 1f);
        }else if(PlayerController.Health == 3)
        {
            bar.localScale = new Vector3(0.6f, 1f);
        }else if(PlayerController.Health == 2)
        {
            bar.localScale = new Vector3(0.4f, 1f);
        }else if(PlayerController.Health == 1)
        {
            bar.localScale = new Vector3(0,2f, 1f);
        }else if(PlayerController.Health == 0)
        {
            bar.localScale = new Vector3(0f, 1f);
        }
        
    }
}
