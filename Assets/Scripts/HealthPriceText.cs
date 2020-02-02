using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPriceText : MonoBehaviour
{
    Text PriceText;
    // Start is called before the first frame update
    void Start()
    {
        PriceText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        PriceText.text = "ϴ" + SkillHolder.HealthPrice;
    }
}
