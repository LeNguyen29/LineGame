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
        if (turn.gameTurn == GameTurnState.START)
        {
            spawnBalls();
            turn.setgameTurn(GameTurnState.PLAYER_TURN);
        }
        if (turn.gameTurn == GameTurnState.COMPUTER_TURN)
        {
            Debug.Log("Comp turn");
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
