using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class BallMovementBase : MonoBehaviour
{
    //private PathFinder pathFinder;
    private PathFinderM pathFinder;

    private BallMovement ballMove;

    private bool reachTarget;

    private GridHandler gridHandler;

    Vector3 startPosition;

    private TurnSystem turn;

    private BallManager manager;

    public bool isGhost;

    private void Awake()
    {
        turn = FindObjectOfType<TurnSystem>();

        ballMove = GetComponent<BallMovement>();

        gridHandler = FindObjectOfType<GridHandler>();

        manager = GetComponent<BallManager>();

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
            /*if (Input.GetMouseButtonDown(0))
            {
                if (!pathFinder.getNode(UtilsClass.GetMouseWorldPosition()).isWalkable)
                {
                    manager.toggleSelect(false);
                    manager.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
                }

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
            }*/

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).tapCount == 1)
                {
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                    touchPos.z = 0f;

                    if (!pathFinder.getNode(touchPos).isWalkable)
                    {
                        manager.toggleSelect(false);
                        manager.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
                    }

                    if (!isGhost)
                    {
                        startPosition = transform.position;
                        List<Vector3> movePosList = pathFinder.findPathVectorList(transform.position, touchPos);
                        if (movePosList != null)
                        {
                            ballMove.setMove(true);
                            ballMove.setMoveVectorList(movePosList);
                        }
                    }
                    else
                    {
                        PathGridNode currentNode = pathFinder.getNode(transform.position);
                        PathGridNode targetNode = pathFinder.getNode(touchPos);
                        Vector3 movePos = pathFinder.getNodeWorldPosition(targetNode.x, targetNode.y);
                        if (movePos != null && targetNode.isWalkable == true)
                        {
                            ballMove.setMove(true);
                            ballMove.setMovePosition(movePos + new Vector3(gridHandler.cellSize, gridHandler.cellSize) * 0.5f);
                            currentNode.isWalkable = true;
                        }
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

    private void moveWithTouch()
    {
        if (Input.GetTouch(0).tapCount == 1)
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPos.z = 0f;

            if (!pathFinder.getNode(touchPos).isWalkable)
            {
                manager.toggleSelect(false);
                manager.ballAnim.changeAnimationState(BallAnimState.BALL_IDLE);
            }

            if (!isGhost)
            {
                startPosition = transform.position;
                List<Vector3> movePosList = pathFinder.findPathVectorList(transform.position, touchPos);
                if (movePosList != null)
                {
                    ballMove.setMove(true);
                    ballMove.setMoveVectorList(movePosList);
                }
            }
            else
            {
                PathGridNode currentNode = pathFinder.getNode(transform.position);
                PathGridNode targetNode = pathFinder.getNode(touchPos);
                Vector3 movePos = pathFinder.getNodeWorldPosition(targetNode.x, targetNode.y);
                if (movePos != null && targetNode.isWalkable == true)
                {
                    ballMove.setMove(true);
                    ballMove.setMovePosition(movePos + new Vector3(gridHandler.cellSize, gridHandler.cellSize) * 0.5f);
                    currentNode.isWalkable = true;
                }
            }
        }
    }

    public void setUpPathfinder(int width, int height, float cellSize, Vector3 spawnPosition)
    {
        pathFinder = new PathFinderM(height, width, cellSize, spawnPosition);
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
