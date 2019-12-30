using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public GameObject Dialog;
    private void Start()
    {

    }

    public void StartRandomLevel()
    {
        SceneManager.LoadScene("RandomLevel");
    }
    public void StartBossFight1()
    {
        SceneManager.LoadScene("BossFight1");
    }
    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void QuitLevel()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void DestroyDialog()
    {
        Destroy(Dialog);
    }
}
