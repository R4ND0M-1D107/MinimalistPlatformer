using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammoController : MonoBehaviour
{

    private bool isPickedUp;
    public Transform PickCheck;
    public float AmmoCheckRadius;
    public LayerMask whatIsPicker;
    public GameObject self;
    public bool Shotgun;
    public bool Fireball;
    public bool Laser;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPickedUp = Physics2D.OverlapCircle(PickCheck.position, AmmoCheckRadius, whatIsPicker);
        if(isPickedUp == true)
        {
            if (Shotgun == true)
            {
                PlayerController.shotgunAmmo += 3;
                Destroy(self);
            }
            else if(Laser == true)
            {
                PlayerController.laserAmmo += 3;
                Destroy(self);
            }
            else if(Fireball == true)
            {
                PlayerController.fireballAmmo += 3;
                Destroy(self);
            }
            
        }

    }
}
