using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public static bool DropJump;
    public static bool DoubleJump;
    public static float TimesPurchased;
    public static float HealthPrice = 100;
    public static float maxHealth = 1;
    // Start is called before the first frame update
    public void ActivateShield()
    {
        if(Score.ScoreValue >= shieldPriceText.PriceValue)
        {
            Score.ScoreValue -= shieldPriceText.PriceValue;
            Debug.Log("Skill bought");
            TimesPurchased++;
        }else if(Score.ScoreValue < shieldPriceText.PriceValue)
        {
            Debug.Log("Insuficient funds");
        }
        
    }
    public void ActivateDropJump()
    {
        if (DropJump == true)
        {
            Debug.Log("Skill already bought");
        }
        else if (Score.ScoreValue >= 1000)
        {
            DropJump = true;
            Score.ScoreValue -= 1000;
            Debug.Log("Skill bought");
        }
        else if (Score.ScoreValue < 1000)
        {
            Debug.Log("Insuficient funds");
        }
    }
    public void ActivateDoubleJump()
    {
        if (DoubleJump == true)
        {
            Debug.Log("Skill already bought");
        }
        else if (Score.ScoreValue >= 1000)
        {
            DoubleJump = true;
            Score.ScoreValue -= 1000;
            Debug.Log("Skill bought");
        }
        else if (Score.ScoreValue < 1000)
        {
            Debug.Log("Insuficient funds");
        }
    }

    public void IncreaseHealth()
    {
        if (Score.ScoreValue >= HealthPrice)
        {
            maxHealth++;
            Score.ScoreValue -= HealthPrice;
            HealthPrice *= 2;
        }
    }
}
