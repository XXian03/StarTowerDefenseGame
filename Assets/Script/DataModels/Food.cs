using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Food 
{
    public int Id;
    public string Name;
    public Action<GridObject> FoodEffects;
    public GridObject GridObject;



    public Food(int _id, string _name, Action<GridObject> _act)
    {
        Id = _id;
        Name = _name;
        FoodEffects = _act;
    }


    public void SetToGridObject(GridObject _obj)
    {
        GridObject = _obj;
    }


    public void AtkUp (int x ,GridObject gridObject)
    {
        gridObject.EntityOnGrid.EntityStats.Atk += x;
    }

}
