using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("New Scene Loaded.");
        SceneManager.LoadScene("PlayScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
