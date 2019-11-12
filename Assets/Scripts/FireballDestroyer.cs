using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDestroyer : MonoBehaviour
{
    
    public GameObject fireball;
 
    void Start(){
        StartCoroutine (Destroy());
    }
 
    IEnumerator Destroy(){
        yield return new WaitForSeconds(2);
        Destroy(fireball);
    }
}
