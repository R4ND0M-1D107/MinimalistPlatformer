﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel3 : MonoBehaviour
{

    public void NextLevel2()
    {
        SceneManager.LoadScene("Level3");
    }
}
