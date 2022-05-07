using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GridHandler : MonoBehaviour
{
    public int width = 1, height = 1;
    public float cellSize = 1;

    public Vector3 spawnPosition;

    //private PathFinder pathFinder;
    private PathFinderM pathFinder;
    private PathGridNode[,] gridArray;

    [SerializeField] private Material lineMaterial;

    private Vector3 topLeftGrid, topRightGrid, bottomRightGrid;

    private void Awake()
    {
        spawnPosition = transform.position - new Vector3(width, height) * cellSize * 0.5f;

        topRightGrid = transform.position + new Vector3(width, height) * cellSize * 0.5f;
        topLeftGrid = transform.position + new Vector3(-width, height) * cellSize * 0.5f;
        bottomRightGrid = transform.position + new Vector3(width, -height) * cellSize * 0.5f;

        //pathFinder = new PathFinder(height, width, cellSize, spawnPosition);
        pathFinder = new PathFinderM(height, width, cellSize, spawnPosition);
    }

    private void Start()
    {
        gridArray = pathFinder.getGridArray();
        Debug.Log("Node count: " + gridArray.Length);

        //drawLine(bottomLeftGrid, bottomRightGrid);
        //drawLine(bottomLeftGrid, topLeftGrid);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                drawLine(pathFinder.getNodeWorldPosition(x, y), pathFinder.getNodeWorldPosition(x, y + 1));
                drawLine(pathFinder.getNodeWorldPosition(x, y), pathFinder.getNodeWorldPosition(x + 1, y));
            }
        }
        drawLine(topLeftGrid, topRightGrid);
        drawLine(topRightGrid, bottomRightGrid);
    }

    private void FixedUpdate()
    {
        //getWalkableNodeList();
    }

    public void getGridSize(out int widthSize, out int heightSize)
    {
        widthSize = width * (int) cellSize;
        heightSize = height * (int)cellSize;
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
                    //Debug.Log($"Node [{gridArray[x, y]}] is walkable");
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

    private void drawLine(Vector3 startPos, Vector3 endPos)
    {
        Vector3 direction = (endPos - startPos).normalized;
        float eulerZ = UtilsClass.GetAngleFromVectorFloat(direction) - 90f;

        float distance = Vector3.Distance(startPos, endPos);
        Vector3 lineSpawnPos = startPos + direction * distance * 0.5f;

        World_Mesh mesh = World_Mesh.Create(lineSpawnPos, eulerZ, .5f, distance, lineMaterial, null, 1000);
    }
}
