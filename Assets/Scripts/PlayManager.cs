using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    // Start is called before the first frame update

    int moveNumber = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GridClick(int moveNumber)
    {
        if(moveNumber % 2 == 1)
        {
            spawnCircle();
        }
        else
        {
            spawnCross();
        }
    }

    private void MoveCounter()
    {

    }
}
