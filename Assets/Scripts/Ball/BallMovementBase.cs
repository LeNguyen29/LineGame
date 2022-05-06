using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BallMovementBase : MonoBehaviour
{
    public int width, height;
    public float cellSize;

    //private PathFinder pathFinder;
    private PathFinderM pathFinder;

    private BallMovement ballMove;

    private bool reachTarget;

    private GridHandler gridHandler;

    Vector3 startPosition;

    private TurnSystem turn;

    public bool isGhost;

    private void Awake()
    {
        turn = FindObjectOfType<TurnSystem>();

        ballMove = GetComponent<BallMovement>();

        gridHandler = FindObjectOfType<GridHandler>();

        ballMove.setBase(this);
    }

    void Start()
    {
        pathFinder = gridHandler.getPathFinder();
    }

    public void Execute()
    {
        if (turn.gameTurn == GameTurnState.PLAYER_TURN)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!isGhost)
                {
                    startPosition = transform.position;
                    List<Vector3> movePosList = pathFinder.findPathVectorList(transform.position, UtilsClass.GetMouseWorldPosition());
                    if (movePosList != null)
                    {
                        ballMove.setMove(true);
                        ballMove.setMoveVectorList(movePosList);
                    }
                }
                else
                {
                    PathGridNode currentNode = pathFinder.getNode(transform.position);
                    PathGridNode targetNode = pathFinder.getNode(UtilsClass.GetMouseWorldPosition());
                    Vector3 movePos = pathFinder.getNodeWorldPosition(targetNode.x, targetNode.y);
                    if (movePos != null && targetNode.isWalkable == true)
                    {
                        ballMove.setMove(true);
                        ballMove.setMovePosition(movePos + new Vector3(gridHandler.cellSize, gridHandler.cellSize) * 0.5f);
                        currentNode.isWalkable = true;
                    }
                }
            }

            if (reachTarget)
            {
                pathFinder.getNode(startPosition).setWalkable(true);
                pathFinder.getNode(transform.position).setWalkable(false);

                turn.setFinishPlayerTurn(true);
            }
        }
    }

    public void setUpPathfinder(int width, int height, float cellSize, Vector3 spawnPosition)
    {
        pathFinder = new PathFinderM(height, width, cellSize, spawnPosition);
    }

    public override string ToString()
    {
        return $"({height}, {width})";
    }

    public Vector3 selectRandomPoint()
    {
        int randomX = Random.Range(0, width);
        int randomY = Random.Range(0, height);

        return pathFinder.getNodeWorldPosition(randomX, randomY);
    }

    public PathFinderM getPathFinder()
    {
        return pathFinder;
    }

    public void setReachTarget(bool val)
    {
        reachTarget = val;
    }

    public bool getReachTarget()
    {
        return reachTarget;
    }
}
