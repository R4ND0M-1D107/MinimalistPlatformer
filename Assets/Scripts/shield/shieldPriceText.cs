using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldPriceText : MonoBehaviour
{
    Text PriceText;
    public static float PriceValue;
    // Start is called before the first frame update
    void Start()
    {
        PriceText = GetComponent<Text>() ;
        
    }

    // Update is called once per frame
    void Update()
    {
        PriceText.text = "ϴ" + PriceValue;
        PriceValue = 500.0f * (SkillHolder.TimesPurchased + 1);
    }
}
