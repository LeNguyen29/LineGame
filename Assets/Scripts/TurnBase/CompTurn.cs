using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompTurn : MonoBehaviour
{
    public BallSpawner ballSpawner;

    private TurnSystem turn;

    private void Awake()
    {
        turn = FindObjectOfType<TurnSystem>();
    }

    private void Start()
    {
        ballSpawner = GetComponent<BallSpawner>();
    }

    private void Update()
    {
        // Spawn in balls at start of game
        if (turn.gameTurn == GameTurnState.START)
        {
            spawnBalls();
            turn.setgameTurn(GameTurnState.PLAYER_TURN);
        }

        // Spawn and check for balls of same color
        if (turn.gameTurn == GameTurnState.COMPUTER_TURN)
        {
            spawnBalls();
            turn.setgameTurn(GameTurnState.PLAYER_TURN);
        }
    }

    public void spawnBalls()
    {
        ballSpawner.executeSpawn();
    }

    public void checkBall()
    {

    }
}
