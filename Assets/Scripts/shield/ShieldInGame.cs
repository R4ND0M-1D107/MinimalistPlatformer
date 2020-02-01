using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldInGame : MonoBehaviour
{
    Text shieldCount;
    // Start is called before the first frame update
    void Start()
    {
        shieldCount = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        shieldCount.text = "" + PlayerController.ShieldUses;
    }
}
