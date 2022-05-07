using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinderM
{
    private const int MOVE_STRAIGHT_COST = 10;

    private GridBase<PathGridNode> grid;
    private List<PathGridNode> openList;
    private List<PathGridNode> closeList;

    public static PathFinderM INSTANCE { get; private set; }

    private Vector3 originPosition;

    public PathFinderM(int height, int width, float cellSize, Vector3 originPosition)
    {
        this.originPosition = originPosition;

        grid = new GridBase<PathGridNode>(height, width, cellSize, originPosition, (GridBase<PathGridNode> grid, int x, int y) => new PathGridNode(grid, x, y));

        if (INSTANCE == null)
            INSTANCE = this;
    }

    public List<Vector3> findPathVectorList(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        grid.getGridXY(startWorldPosition, out int startX, out int startY);
        grid.getGridXY(endWorldPosition, out int endX, out int endY);

        Debug.Log("Start: " + startX + "," + startY);
        Debug.Log("End: " + endX + "," + endY);

        List<PathGridNode> path = findPath(startX, startY, endX, endY);

        List<Vector3> pathVectorList = new List<Vector3>();
        if (path != null)
        {
            foreach (var node in path)
            {
                pathVectorList.Add(originPosition + new Vector3(grid.getCellSize(), grid.getCellSize()) * 0.5f + new Vector3(node.x, node.y) * grid.getCellSize());
            }
            return pathVectorList;
        }
        else
            return null;
    }

    public List<PathGridNode> findPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
    {
        //Debug.Log("Start: ("+ startWorldPosition.ToString() + ") - End: (" + endWorldPosition.ToString() + ")");
        grid.getGridXY(startWorldPosition, out int startX, out int startY);
        grid.getGridXY(endWorldPosition, out int endX, out int endY);

        return findPath(startX, startY, endX, endY);
    }

    public List<PathGridNode> findPath(int startX, int startY, int endX, int endY)
    {
        /*        Debug.Log("Start Node: (" + startX + " " + startY + ") - End Node: (" + endX + " " + endY + ")");
                Debug.Log("FINDING PATH");*/
        PathGridNode startNode = grid.getGridObject(startX, startY);
        PathGridNode endNode = grid.getGridObject(endX, endY);

        /*        Debug.Log("Start node: " + startNode.ToString());

                if (endNode == null)
                    Debug.Log("NO end node");
                Debug.Log("End node: " + endNode.ToString());*/

        if (startNode == null || endNode == null)
        {
            // Invalid Path
            Debug.Log("Invalid path");
            return null;
        }


        openList = new List<PathGridNode>() { startNode };
        closeList = new List<PathGridNode>();

        for (int x = 0; x < grid.getHeight(); x++)
        {
            for (int y = 0; y < grid.getWidth(); y++)
            {
                //Debug.Log("Instatiating Node " + x + " " + y);
                PathGridNode pathNode = grid.getGridObject(y, x);
                pathNode.gCost = 99999999;
                pathNode.calculateFCost();
                pathNode.parentNode = null;
            }
        }

        startNode.gCost = 0;
        startNode.hCost = calculateMoveCost(startNode, endNode);
        startNode.calculateFCost();

        while (openList.Count > 0)
        {
            //Debug.Log("Open list count: " + openList.Count);

            PathGridNode currentNode = getLowestFCostNode(openList);
            //Debug.Log("Current node: " + currentNode.ToString() + " || G cost: " + currentNode.gCost);

            if (currentNode == endNode)
            {
                //Debug.Log("PATH FOUND");
                return calculatePath(currentNode);
            }

            openList.Remove(currentNode);
            closeList.Add(currentNode);

            foreach (PathGridNode node in getNeighbourNodes(currentNode))
            {
                //Debug.Log("Node " + node.ToString() + " || G cost: " + node.gCost); 
                if (closeList.Contains(node))
                {
                    //Debug.Log("Already searched node " + currentNode.ToString());
                    continue;
                }
                if (node.isWalkable == false)
                {
                    closeList.Add(node);
                    continue;
                }

                int expectedGCost = currentNode.gCost + calculateMoveCost(currentNode, node);
                //Debug.Log("Expected G cost: " + expectedGCost);

                if (expectedGCost < node.gCost)
                {
                    //Debug.Log("Evaluating node " + node.ToString());
                    node.parentNode = currentNode;
                    node.gCost = expectedGCost;
                    node.hCost = calculateMoveCost(node, endNode);
                    node.calculateFCost();

                    if (!openList.Contains(node))
                        openList.Add(node);
                }

            }
        }

        return null;
    }

    public List<PathGridNode> calculatePath(PathGridNode node)
    {
        List<PathGridNode> path = new List<PathGridNode>();
        PathGridNode currentNode = node;
        path.Add(currentNode);
        while (currentNode.parentNode != null)
        {
            path.Add(currentNode.parentNode);
            currentNode = currentNode.parentNode;
        }

        /*        for (int i = 0; i < path.Count; i++)
                {
                    Debug.Log(path[i].x + " " + path[i].y);
                }*/
        path.Reverse();
        return path;
    }

    public List<PathGridNode> getNeighbourNodes(PathGridNode currentNode)
    {
        List<PathGridNode> neighbourList = new List<PathGridNode>();

        if (currentNode.x - 1 >= 0)
        {
            // Left
            neighbourList.Add(getNode(currentNode.x - 1, currentNode.y));
        }
        if (currentNode.x + 1 < grid.getWidth())
        {
            // Right
            neighbourList.Add(getNode(currentNode.x + 1, currentNode.y));
        }
        // Down
        if (currentNode.y - 1 >= 0) neighbourList.Add(getNode(currentNode.x, currentNode.y - 1));
        // Up
        if (currentNode.y + 1 < grid.getHeight()) neighbourList.Add(getNode(currentNode.x, currentNode.y + 1));

        return neighbourList;
    }

    public PathGridNode getNode(Vector3 worldPosition)
    {
        grid.getGridXY(worldPosition, out int x, out int y);
        return getNode(x, y);
    }

    public PathGridNode getNode(int x, int y)
    {
        return grid.getGridObject(x, y);
    }

    public Vector3 getNodeWorldPosition(int x, int y)
    {
        return grid.getNodeWorldPosition(x, y);
    }

    public PathGridNode getLowestFCostNode(List<PathGridNode> nodeList)
    {
        PathGridNode currentNode = nodeList[0];

        for (int i = 0; i < nodeList.Count; i++)
        {
            if (nodeList[i].fCost < currentNode.fCost)
                currentNode = nodeList[i];
        }

        return currentNode;
    }

    public int calculateMoveCost(PathGridNode a, PathGridNode b)
    {
        int distanceX = Mathf.Abs(a.x - b.x);
        int distanceY = Mathf.Abs(a.y - b.y);
        int straightDistance = Mathf.Abs(distanceX - distanceY);
        return MOVE_STRAIGHT_COST * straightDistance;
    }

    public PathGridNode[,] getGridArray()
    {
        return grid.getGridArray();
    }
}
