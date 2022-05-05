using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTurnState
{
    START,
    PLAYER_TURN,
    COMPUTER_TURN,
    LOST
}

public class TurnSystem : MonoBehaviour
{
    public GameTurnState gameTurn;

    [SerializeField] private bool playerTurnFinish;
    [SerializeField] private bool computerTurnFinish;

    public CompTurn comp;

    private void Start()
    {
        playerTurnFinish = false;
        computerTurnFinish = false;

        setUpGame();
    }

    private void Update()
    {
        //Debug.Log("Current turn: " + gameTurn);
        switch (gameTurn)
        {
            case GameTurnState.PLAYER_TURN:
                playerTurn();
                break;
            case GameTurnState.COMPUTER_TURN:
                computerTurn();
                break;
            case GameTurnState.LOST:
                break;
            default:
                break;
        }
    }

    public void setUpGame()
    {
        Debug.Log("STARTING GAME...");
        gameTurn = GameTurnState.START;
    }

    private void playerTurn()
    {
        //Debug.Log("PLAYER TURN...");

        if (playerTurnFinish)
        {
            gameTurn = GameTurnState.COMPUTER_TURN;
            playerTurnFinish = false;
        }
    }

    private void computerTurn()
    {
        Debug.Log("COMPUTER TURN...");

        if (computerTurnFinish)
        {
            if (gameTurn != GameTurnState.LOST)
            {
                gameTurn = GameTurnState.PLAYER_TURN;
                playerTurn();
                computerTurnFinish = false;
            }
            else
            {
                Debug.Log("GAME OVER");
            }
        }
    }

    public void setFinishPlayerTurn(bool value)
    {
        Debug.Log("PLAYER TURN FINSIHED");
        playerTurnFinish = value;
    }

    public void setFinishComputerTurn(bool value)
    {
        computerTurnFinish = value;
    }

    public void setgameTurn(GameTurnState turn)
    {
        this.gameTurn = turn;
    }
}
