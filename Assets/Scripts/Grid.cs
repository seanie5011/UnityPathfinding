using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Grid {
    //
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;
    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int y;
    }

    // properties of grid
    private int width;
    private int height;
    private float cellsize;
    // the 2D array of the grid
    private int[,] gridArray;
    // array used to store values of each cell
    private TextMesh[,] debugTextArray;
    // tell where the grid positions should read from
    private Vector3 originPosition;

    // constructor
    public Grid(int width, int height, float cellsize, Vector3 originPosition)
    {
        // construct array
        this.width = width;
        this.height = height;
        this.cellsize = cellsize;
        gridArray = new int[width, height];
        debugTextArray = new TextMesh[width, height];
        this.originPosition = originPosition;

        // loop through all x and y
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                // create text to show the grid position
                // offset position by half the cellsize so that the text is in the middle
                debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y].ToString(), null, GetWorldPosition(x, y) + new Vector3(cellsize, cellsize) * 0.5f, 20, Color.white, TextAnchor.MiddleCenter);
                // create lines to separate them
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
            }
        }
        // these lines to close off the grid
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);

        // 
        OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) => {
            debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y].ToString();
        };
    }

    // getters
    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellsize()
    {
        return cellsize;
    }

    // use cellsize to get world position (orthographic 2D)
    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * cellsize + originPosition;
    }

    // get x and y from a vector3, out these to the inputted variables
    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        // factor in cellsize
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellsize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y / cellsize);
    }

    // set the value of a grid cell
    public void SetValue(int x, int y, int value)
    {
        // if x or y are not valid, ignore this
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            gridArray[x, y] = value;
            if (OnGridValueChanged != null) OnGridValueChanged(this, new OnGridValueChangedEventArgs { x = x, y = y });  // call the event
        }
    }

    // overloading the SetValue function with a version for using the world position
    public void SetValue(Vector3 worldPosition, int value)
    {
        // get x and y and then set value normally
        int x, y;
        GetXY(worldPosition, out x, out y);
        SetValue(x, y, value);
    }

    // get the value of a specific cell
    public int GetValue(int x, int y)
    {
        // if x or y are not valid, ignore this
        if (x >= 0 && y >= 0 && x < width && y < height)
        {
            return gridArray[x, y];
        } else
        {
            // otherwise, return -1
            return -1;
        }
    }

    // overloading for world position version
    public int GetValue(Vector3 worldPosition)
    {
        // get x and y and then get value normally
        int x, y;
        GetXY(worldPosition, out x, out y);
        return GetValue(x, y);
    }

    // add to the already set value
    public void AddValue(int x, int y, int value)
    {
        SetValue(x, y, GetValue(x, y) + value);
    }

    // overloading for world position version
    public void AddValue(Vector3 worldPosition, int value)
    {
        // get x and y and then add value normally
        int x, y;
        GetXY(worldPosition, out x, out y);
        AddValue(x, y, value);
    }
}
