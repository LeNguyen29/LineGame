using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    private GridHandler gridHandler;

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
    }

    private void Update()
    {
        if (gridHandler.getWalkableNodeList().Count <= 0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
    }
}
