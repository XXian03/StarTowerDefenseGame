using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Food 
{
    public int Id;
    public string Name;
    public Action<Food> FoodEffects;
    public GameStateEnum NextState;
    public GridObject GridObject;


    public Food (int _id ,string _name , Action<Food> _act, GameStateEnum _nextState)
    {
        Id = _id;
        Name = _name;
        FoodEffects = _act;
        NextState = _nextState;
    }

    public Food(int _id, string _name, Action<Food> _act)
    {
        Id = _id;
        Name = _name;
        FoodEffects = _act;
    }


    public void SetToGridObject(GridObject _obj)
    {
        GridObject = _obj;
    }


}
