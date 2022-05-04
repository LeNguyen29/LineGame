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

    public bool reachTarget;

    private GridHandler gridHandler;

    Vector3 startPosition;

    private void Awake()
    {
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
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = transform.position;
            List<Vector3> movePosList = pathFinder.findPathVectorList(transform.position, UtilsClass.GetMouseWorldPosition());
            if (movePosList != null)
            {
                ballMove.setMove(true);
                ballMove.setMoveVectorList(movePosList);
            }
        }

        if (reachTarget)
        {
            pathFinder.getNode(startPosition).setWalkable(true);
            pathFinder.getNode(transform.position).setWalkable(false);
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
}
