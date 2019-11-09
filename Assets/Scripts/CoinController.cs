using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    
    public GameObject coin;
    
    private bool isPickedUp;
   public Transform PickCheck;
   public float CoinCheckRadius;
   public LayerMask whatIsPicker;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isPickedUp = Physics2D.OverlapCircle(PickCheck.position, CoinCheckRadius, whatIsPicker);

        if (isPickedUp == true) {
            Score.ScoreValue += 1;
            Destroy(coin);
        }
    }
}
