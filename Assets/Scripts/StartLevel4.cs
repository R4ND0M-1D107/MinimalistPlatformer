using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel4 : MonoBehaviour
{
    public void NextLevel3()
    {
        SceneManager.LoadScene("Level4");
    }
}
