using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGridNode
{
    private GridBase<PathGridNode> grid;
    public int x, y;

    public int gCost;
    public int hCost;
    public int fCost;

    public PathGridNode parentNode;
    public bool isWalkable;

    public PathGridNode(GridBase<PathGridNode> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
        isWalkable = true;
    }

    public void calculateFCost()
    {
        fCost = gCost + hCost;
    }

    public void setWalkable(bool value)
    {
        isWalkable = value;
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}
