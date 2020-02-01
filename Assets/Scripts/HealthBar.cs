using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Transform Target;
    float scale;
    Transform bar;
    Transform target;
    float modifier;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        modifier = 1f / SkillHolder.maxHealth;
        Debug.Log("modifier is : " + modifier);
    }

    // Update is called once per frame
    /*
    private void FixedUpdate()
    {
        transform.position = target.position + new Vector3(-14, 8, 1);
    }
    */
    void Update()
    {
        if(PlayerController.takeDamage == true) { 
            bar.localScale -= new Vector3(modifier, 0f);
            PlayerController.takeDamage = false;
        }
        
    }
}
