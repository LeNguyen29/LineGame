using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    private GridHandler gridHandler;
    private LevelManager levelManager;
    private ScoreTracker score;

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        score = FindObjectOfType<ScoreTracker>();
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
        if (score.getScore() > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score.getScore());
        }
        Debug.Log("Game Over");
        LevelManager.INSTANCE.ToGameOver();
    }
}
