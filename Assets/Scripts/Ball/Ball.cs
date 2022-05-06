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

public enum BallState
{
    QUEUE,
    READY,
    STANDBY
}

public class Ball : MonoBehaviour
{
    public BallState[] state = {BallState.QUEUE, BallState.READY, BallState.STANDBY};
    public BallType type;
    public Color color;

    [SerializeField] private int score = 1;

    private GridHandler gridHandler;
    private ScoreTracker scoreTracker;
    private BallAnimationCon ballAnim;

    private void Start()
    {
        gridHandler = FindObjectOfType<GridHandler>();
        scoreTracker = FindObjectOfType<ScoreTracker>();
        ballAnim = GetComponent<BallAnimationCon>();
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
        scoreTracker.addScore(score);
        ballAnim.changeAnimationState(BallAnimState.BALL_EXPLODE);
    }

    public void disableBall()
    {
        gameObject.SetActive(false);
    }
}
