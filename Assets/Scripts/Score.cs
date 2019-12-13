using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int ScoreValue;
    public static int DeathCount;
    Text score;
    public bool coin;
    // Start is called before the first frame update
    void Start()
    {
        ScoreValue = 0;
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (coin == true)
        {
            score.text = "Coins : " + ScoreValue;
        }else if (coin == false) {
            score.text = "Deaths : " + DeathCount;
        }
    }
}
