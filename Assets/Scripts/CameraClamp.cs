using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, -15f, Mathf.Infinity), Mathf.Clamp(target.position.y, -8f, 0f), transform.position.z);
    }
}
