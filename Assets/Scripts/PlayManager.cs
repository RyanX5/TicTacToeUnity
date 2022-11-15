using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject circle;
    [SerializeField] GameObject cross;

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

    public void GridClick()
    {
        if(moveNumber % 2 == 1)
        {
            spawnCircle();
            moveNumber += 1;
            print("Spawned circle!");
        }
        else
        {
            spawnCross();
            moveNumber += 1;
            print("Spawned cross!");

        }
    }

    private void MoveCounter()
    {
        //moveNumber += 1;
    }

    void spawnCircle()
    {
        GameObject.Instantiate(circle, transform.position, Quaternion.identity);
    }

    void spawnCross()
    {
        GameObject.Instantiate(cross, transform.position, Quaternion.identity);
    }
}
