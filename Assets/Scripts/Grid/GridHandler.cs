using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    public int width = 1, height = 1;
    public float cellSize = 1;

    public Vector3 spawnPosition;

    //private PathFinder pathFinder;
    private PathFinderM pathFinder;
    private PathGridNode[,] gridArray;

    private void Awake()
    {
        spawnPosition = transform.position - new Vector3(width, height) * cellSize * 0.5f;

        //pathFinder = new PathFinder(height, width, cellSize, spawnPosition);
        pathFinder = new PathFinderM(height, width, cellSize, spawnPosition);
    }

    private void Start()
    {
        gridArray = pathFinder.getGridArray();
        Debug.Log("Node count: " + gridArray.Length);
    }

    private void FixedUpdate()
    {
        //getWalkableNodeList();
    }

    public Vector3 getSpawnPos()
    {
        return spawnPosition;
    }

    public override string ToString()
    {
        return $"({height}, {width})";
    }

    public PathFinderM getPathFinder()
    {
        return pathFinder;
    }

    public List<PathGridNode> getWalkableNodeList()
    {
        List<PathGridNode> nodeList = new List<PathGridNode>();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (gridArray[x, y].isWalkable)
                {
                    Debug.Log($"Node [{gridArray[x, y]}] is walkable");
                    nodeList.Add(gridArray[x, y]);
                }
            }
        }

        return nodeList;
    }

    public int getNumberOfNodes()
    {
        return gridArray.Length;
    }
}
