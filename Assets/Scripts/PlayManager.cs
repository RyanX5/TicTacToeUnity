using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    int[,] mat = new int[3, 3];
    public int moveCount = 0;
    [SerializeField] GameObject gameOverText;
    void Start()
    {
        gameOverText.SetActive(false);
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
        {
            GameOver();
            
        }
    }

    void GameOver()
    {
        print("Game Over!");
        gameOverText.SetActive(true);
    }




    public void CheckWin(Vector3Int value)
    {
        int currR = value.x - 1;
        int currC = value.y - 1;
        int currVal = 0;

        if (moveCount % 2 == 0)
        {
            currVal = 1;
        }
        else
            currVal = 2;

        mat[currR, currC] = currVal;

        for (int i = 0; i < 3; ++i)
        {
            for(int j = 0; j < 3; ++j)
            {
                print(i +","+ j+" = " + mat[i, j]);
            }
        }
    }
}
