using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GridBase<TGridObject>
{
    public event EventHandler OnGridObjectChange;

    public class OnGridObjectChangeEventArgs : EventArgs
    {
        public int x, y;
    }

    private int height, width;
    private float cellsize;

    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;

    private Vector3 originPosition;

    private bool debugMode = true;

    public GridBase(int height, int width, float cellsize, Vector3 originPosition, Func<GridBase<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.height = height;
        this.width = width;
        this.cellsize = cellsize;
        gridArray = new TGridObject[width, height];

        this.originPosition = originPosition;

        // GetLength(0) is width (column)
        // GetLength(1) is height (row)

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = createGridObject(this, x, y);
            }
        }

        if (debugMode)
        {
            /*            Debug.Log("Height: " + height + " Width: " + width);
                        Debug.Log("Node count: " + gridArray.Length);
                        Debug.Log("Columns: "+ gridArray.GetLength(0) + " Rows: " + gridArray.GetLength(1));*/

            debugTextArray = new TextMesh[width, height];

            for (int x = 0; x < gridArray.GetLength(0); x++)
            {
                for (int y = 0; y < gridArray.GetLength(1); y++)
                {
                    debugTextArray[x, y] = Utils.createWorldText(gridArray[x, y]?.ToString(), null, getNodeWorldPosition(x, y) + new Vector3(cellsize, cellsize) * 0.5f, (int)cellsize * 4, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(getNodeWorldPosition(x, y), getNodeWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(getNodeWorldPosition(x, y), getNodeWorldPosition(x + 1, y), Color.white, 100f);
                }
            }

            Debug.DrawLine(getNodeWorldPosition(0, height), getNodeWorldPosition(width, height), Color.white, 100f);
            Debug.DrawLine(getNodeWorldPosition(width, 0), getNodeWorldPosition(width, height), Color.white, 100f);
        }

    }

    public float getCellSize()
    {
        return cellsize;
    }

    public int getHeight()
    {
        return height;
    }

    public int getWidth()
    {
        return width;
    }

    public TGridObject getGridObject(int x, int y)
    {
        if (x < width && y < height && x >= 0 && y >= 0)
            return gridArray[x, y];
        else
        {
            Debug.Log("Invalid grid XY: " + x + " " + y);
            return default(TGridObject);
        }
    }

    public TGridObject getGridObject(Vector3 worldPosition)
    {
        int x, y;
        getGridXY(worldPosition, out x, out y);
        return getGridObject(x, y);
    }

    public void getGridXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellsize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellsize);
    }

    public void setGridObject(int x, int y, TGridObject value)
    {
        if (x < width && y < height && x >= 0 && y >= 0)
        {
            gridArray[x, y] = value;
            OnGridObjectChange?.Invoke(this, new OnGridObjectChangeEventArgs { x = x, y = y });
            debugTextArray[x, y].text = gridArray[x, y].ToString();
        }
    }

    public void triggerGridObjectChange(int x, int y)
    {
        OnGridObjectChange?.Invoke(this, new OnGridObjectChangeEventArgs { x = x, y = y });
    }

    public Vector3 getNodeWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize + originPosition;
    }

    public void setGridObject(Vector3 worldPosition, TGridObject value)
    {
        int x, y;
        getGridXY(worldPosition, out x, out y);
        setGridObject(x, y, value);
    }

    public TGridObject[,] getGridArray()
    {
        return gridArray;
    }
}
