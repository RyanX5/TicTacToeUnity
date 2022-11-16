using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    public int moveCount = 0;
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void increaseCount()
    {
        moveCount++;
        print("Count value: " + moveCount);

        if (moveCount > 9)
            print("Game Over!");
    }
}
