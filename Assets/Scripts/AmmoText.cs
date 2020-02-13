using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoText : MonoBehaviour
{
    public bool Shotgun;
    public bool Fireball;
    public bool Laser;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Laser == true)
        {
            score.text = "" + PlayerController.laserAmmo;
        }
        else if (Shotgun == true)
        {
            score.text = "" + PlayerController.shotgunAmmo;
        }
        else if (Fireball == true)
        {
            score.text = "" + PlayerController.fireballAmmo;
        }
    }
    // Start is called before the first frame update
}
