using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGrid
{

    public int width;   // your cap for width
    public int height;  // your cap for height
    public GridObject[,] GridObjects; // array list for fakeGrid
    public float CellSize; // the size for 1 cell 
    public Vector3 originPosition; 

    // For Loading //
    public FakeGrid (int _width , int _height, GridObject[,] _fakeGrid , float _cellSize , Vector3 _origin)
    {
        width = _width;
        height = _height;
        GridObjects = _fakeGrid;
        CellSize = _cellSize;
        originPosition = _origin;
    }


    // For New Grid // 
    public FakeGrid(int _width, int _height , float _cellSize, Vector3 _origin)
    {
        width = _width;
        height = _height;
        CellSize = _cellSize;
        originPosition = _origin;
        GridObjects = new GridObject[width, height];
    }

    public void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / CellSize); // hard code the origin postition now first? 
        y = Mathf.FloorToInt((worldPosition - originPosition).y / CellSize);


        if (x >= width)
        {
            x = width - 1;
        }
        else if (x < 0)
        {
            x = 0;
        }
        if (y >= height)
        {
            y = height - 1;
        }
        else if (y < 0)
        {
            y = 0;
        }
    }

    public GridObject GetGridObject(int x , int y)
    {
        return GridObjects[x, y];
    }



}
