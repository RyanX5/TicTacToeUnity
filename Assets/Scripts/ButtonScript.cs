using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject circle;
    [SerializeField] GameObject cross;

    [SerializeField] PlayManager playM;
    int moveNumber;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(GridClick);
    }

    // Update is called once per frame
    void Update()
    {
        moveNumber = playM.moveCount;
    }

    public void GridClick()
    {
        if (moveNumber % 2 == 1)
        {
            spawnCircle();
            moveNumber += 1;
           // print("Spawned circle!");
            playM.increaseCount();
        }
        else
        {
            spawnCross();
            moveNumber += 1;
            //print("Spawned cross!");
            playM.increaseCount();

        }
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
