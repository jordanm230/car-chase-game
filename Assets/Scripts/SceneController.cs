using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static string sourceScene;
    void Start()
    {
        sourceScene = "menu";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game Scene");
    }

    public void Garage()
    {
        SceneManager.LoadScene("Garage Scene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Instructions Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits Scene");
    }

    public void Return()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
