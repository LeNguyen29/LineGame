using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum BallType
{
    NORMAL,
    GHOST,
    UKNUCKLE,
    DIO,
    SUS
}

public class Ball : MonoBehaviour
{
    public BallType type;
    public Color color;

    [SerializeField] private int score = 1;

    private GridHandler gridHandler;
    private ScoreTracker scoreTracker;

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        scoreTracker = FindObjectOfType<ScoreTracker>();
    }

    public void setColor(Color color)
    {
        this.color = color;
    }

    public void explode()
    {
        Debug.Log("BOOM");

        // Play explosion animation
        gridHandler.getPathFinder().getNode(transform.position).setWalkable(true);
        scoreTracker.setScore(score);
        gameObject.SetActive(false);
    }
}
