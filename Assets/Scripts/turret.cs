using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public Transform muzzle;
    public GameObject shot;
    bool ShootingDone, WaitingDone;
    // Start is called before the first frame update
    void Start()
    {
        WaitingDone = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShootingDone == true)
        {
            ShootingDone = false;
            StartCoroutine(Waiting());
        }
        if(WaitingDone == true)
        {
            WaitingDone = false;
            StartCoroutine(Shooting());
        }
    }
    void Fire()
    {
        Instantiate(shot, muzzle.position, Quaternion.identity);
    }
    IEnumerator Shooting()
    {
        Fire();
        yield return new WaitForSeconds(0.25f);
        Fire();
        yield return new WaitForSeconds(0.25f);
        Fire();
        yield return new WaitForSeconds(0.25f);
        ShootingDone = true;
    }
    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2f);
        WaitingDone = true;
    }
}
