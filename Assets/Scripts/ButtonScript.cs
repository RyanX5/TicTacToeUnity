using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    //Instances of circle and cross prefab, used for instantiation
    [SerializeField] GameObject circle;
    [SerializeField] GameObject cross;

    //Instance of PlayManager script, to access moveCount and also update it per GridClick() call
    [SerializeField] PlayManager playM;

    //Move number to keep track of moves
    int moveNumber;

    void Start()
    {
        //Grid button, used to call GridClick per click on the button
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(GridClick);
    }

    // Update is called once per frame
    void Update()
    {
        //Get moveCount from PlayManager instance, to keep local variable moveNumber updated
        //Used to know what to instantiate, circle or cross depending on the current move number
        moveNumber = playM.moveCount;
    }

    public void GridClick()
    {
        if (moveNumber % 2 == 1)
        {
            //Spawns circle on the current position of the Grid.
            spawnCircle();

            //Increment local moveNumber variable
            moveNumber += 1;


            //Update moveCount variable on PlayManager script
            playM.increaseCount();

            //Check if there's a winning condition per move
            playM.CheckWin(SendGridInfo());

            //Once everything's called, destroy the object, to avoid repeated instantiation
            Destroy(gameObject);
        }
        else
        {
            //Spawns cross on the current position of the Grid.
            spawnCross();

            //Increment local moveNumber variable
            moveNumber += 1;


            //Update moveCount variable on PlayManager script
            playM.increaseCount();

            //Check if there's a winning condition per move
            playM.CheckWin(SendGridInfo());

            //Once everything's called, destroy the object, to avoid repeated instantiation
            Destroy(gameObject);
        }
    }

    void spawnCircle()
    {
        //Instantiates a circle with zero rotation at the position of the circle
        GameObject.Instantiate(circle, transform.position, Quaternion.identity);
    }

    void spawnCross()
    {
        //Offset tweak values
        float xOffset = 0.0867f;
        float yOffset = -0.2158f;
        Vector2 v = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);

        //Instantiates a cross in similar fashion as circle
        GameObject.Instantiate(cross, v, Quaternion.identity);
    }


    //Function to send values to CheckWin() function in PlayManager
    Vector3Int SendGridInfo()
    {
        //Vector containing the current GridButton's matrix info
        Vector3Int matV = new Vector3Int((gameObject.name[1] - '0'), (gameObject.name[2] - '0'));

        return matV;
    }
}
