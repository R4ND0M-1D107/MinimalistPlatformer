using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public static bool Shield;
    public static bool DropJump;
    public static bool DoubleJump;
    // Start is called before the first frame update
    public void ActivateShield()
    {
        if(Shield == true)
        {
            Debug.Log("Skill already bought");
        }else if(Score.ScoreValue > 1000)
        {
            Shield = true;
            Score.ScoreValue -= 1000;
            Debug.Log("Skill bought");
        }else if(Score.ScoreValue < 1000)
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
        else if (Score.ScoreValue > 1000)
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
}
