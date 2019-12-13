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
    AudioSource pickUp;
    bool neverDone = true;
    
    // Start is called before the first frame update
    void Start()
    {
        pickUp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isPickedUp = Physics2D.OverlapCircle(PickCheck.position, CoinCheckRadius, whatIsPicker);

        if (isPickedUp == true && neverDone == true) {
            neverDone = false;
            pickUp.Play();
            Score.ScoreValue += 1;
            Destroy(coin, (pickUp.clip.length - 0.1f));
        }
    }
}
