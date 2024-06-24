using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridData 
{
    public float CellSize;
    public float PositionX;
    public float PositionY;


    public int Width;
    public int Height;
    public string ListOfTiles;
    

    public GridData(int _width , int _height , string _listOfTiles, float _cellSize, float _positionX , float _positionY )
    {
        Width = _width;
        Height = _height;
        ListOfTiles = _listOfTiles;
        CellSize = _cellSize;
        PositionX = _positionX;
        PositionY = _positionY;

    }
}
