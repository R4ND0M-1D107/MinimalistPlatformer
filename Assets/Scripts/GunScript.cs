﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public static float Rotation = 0.0f;
    public static float flipModifier = 1;
    public float RoationSpeed;
    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("weaponNumber", PlayerController.weaponNumber);
        if (PlayerController.weaponNumber == 1)
        {
            Rotation = Mathf.Clamp(Rotation, -30.0f, 30.0f);
        }else if (PlayerController.weaponNumber == 2)
        {
            Rotation = Mathf.Clamp(Rotation, -15.0f, 15.0f);
        }
        else if (PlayerController.weaponNumber == 3)
        {
            Rotation = Mathf.Clamp(Rotation, -1.0f, 1.0f);
        }
        
        Rotation += RoationSpeed * flipModifier * Input.GetAxis("Mouse Y");
        

        transform.eulerAngles = new Vector3(0.0f, 0.0f, Rotation);
    }
}
