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
            playM.CheckWin(SendValue());
            Destroy(gameObject);
        }
        else
        {
            spawnCross();
            moveNumber += 1;
            playM.increaseCount();
            playM.CheckWin(SendValue());
            Destroy(gameObject);
        }
    }

    void spawnCircle()
    {
        GameObject.Instantiate(circle, transform.position, Quaternion.identity);
    }

    void spawnCross()
    {
        float xOffset = 0.0867f;
        float yOffset = -0.2158f;
        Vector2 v = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
        GameObject.Instantiate(cross, v, Quaternion.identity);
    }

    Vector3Int SendValue()
    {
        Vector3Int matV = new Vector3Int((gameObject.name[1] - '0'), (gameObject.name[2] - '0'));
        return matV;
    }
}
