using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompTurn : MonoBehaviour
{
    private BallSpawner ballSpawner;
    private ColorChecker colorChecker;
    private TurnSystem turn;

    public BallsDisplay ballDisplay;

    private void Awake()
    {
        turn = FindObjectOfType<TurnSystem>();
    }

    private void Start()
    {
        ballSpawner = GetComponent<BallSpawner>();
        colorChecker = GetComponent<ColorChecker>();
    }

    private void Update()
    {
        // Spawn in balls at start of game
        if (turn.gameTurn == GameTurnState.START)
        {
            spawnBalls();
            
            BallsDisplay.INSTANCE.updateList(ballSpawner.getBallList());

            //ScoreTracker.INSTANCE.setScore(0);

            turn.setgameTurn(GameTurnState.PLAYER_TURN);
        }

        // Spawn and check for balls of same color
        if (turn.gameTurn == GameTurnState.COMPUTER_TURN)
        {
            Debug.Log("BEEP COMPUTER TURN");
            spawnBalls();
            BallsDisplay.INSTANCE.updateList(ballSpawner.getBallList());
            checkBall();
            turn.setgameTurn(GameTurnState.PLAYER_TURN);
        }
    }

    public void spawnBalls()
    {
        ballSpawner.executeSpawn();
    }

    public void checkBall()
    {
        colorChecker.setBallList();
        colorChecker.checkListBall();
    }
}
