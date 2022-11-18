using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayManager : MonoBehaviour
{
    int[,] mat = new int[3, 3];
    public int moveCount = 0;
    [SerializeField] GameObject gameOverText;
    [SerializeField] GameObject gameWonText;
    void Start()
    {
        gameOverText.SetActive(false);
        gameWonText.gameObject.SetActive(false);
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

        if (WinCondition(mat))
        {
            gameWonText.GetComponent<TextMeshProUGUI>().SetText("GAME WON!");
            gameWonText.gameObject.SetActive(true);
        }
        else
        {
            
        }

    }

    bool WinCondition(int[,] arr)
    {
        bool isWon = false;

        //Checks for rows
        for (int i = 0; i < 3; ++i)
        {
            if (arr[i, 0] != 0)
            {
                if (arr[i, 0] == arr[i, 1])
                {
                    if (arr[i, 1] == arr[i, 2])
                    {
                        isWon = true;
                        print("Won by rows");
                    }

                }
            }
        }

        //Checks for columns
        for(int i = 0; i < 3; ++i)
        {
            if(arr[0, i] != 0)
            {
                if (arr[0, i] == arr[1, i])
                {
                    if (arr[1, i] == arr[2, i])
                    {
                        isWon = true;
                        print("Won by columns");
                    }

                }
            }
        }

        //Checks for diagonals (top-to-bot)
        if(arr[0, 0] != 0)
        {
            if (arr[0, 0] == arr[1, 1])
            {
                if (arr[1, 1] == arr[2, 2])
                {
                    isWon = true;
                    print("Won by diagonals");
                }
            }

        }

        //Checks for diagonals (topright-to-bot)
        if (arr[0, 2] != 0)
        {
            if (arr[0, 2] == arr[1, 1])
            {
                if (arr[1, 1] == arr[2, 0])
                {
                    isWon = true;
                    print("Won by diagonals");
                }
            }

        }


        return isWon;
    }
}
