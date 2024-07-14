using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridPatternDataBase : MonoBehaviour
{
    [SerializeField] UiHandler uihandler;
    [SerializeField] GameObject gObject;



    private static GridPatternDataBase instance;
    public static GridPatternDataBase Instance => instance;

    public void Awake()
    {
        instance = this;   
    }



    void Start()
    {

    }

    void Update()
    {
        
    }



    public void CreateAttackArea(List<GridObject> _atkGrid, GridObject obj) // obj is character 
    {
        if (_atkGrid == null)
        {
            _atkGrid = new List<GridObject>(); // create a new list to hold all the Attacking Grids (GridObject)
        }

        

        // atkGrid add a new GridObject based on obj's x and y
        _atkGrid.Add(new GridObject(obj.x - 1, obj.y + 1));  // -1 , 1
        _atkGrid.Add(new GridObject(obj.x    , obj.y + 1));  // 0  , 1  
        _atkGrid.Add(new GridObject(obj.x + 1, obj.y + 1));  // 1  , 1  

        _atkGrid.Add(new GridObject(obj.x - 1, obj.y));      // -1 , 0
        _atkGrid.Add(new GridObject(obj.x    , obj.y));      //  0 , 0
        _atkGrid.Add(new GridObject(obj.x + 1, obj.y));      //  1 , 0 

        _atkGrid.Add(new GridObject(obj.x - 1, obj.y - 1));   // -1 , - 1 
        _atkGrid.Add(new GridObject(obj.x    , obj.y - 1));   // 0  , - 1  
        _atkGrid.Add(new GridObject(obj.x + 1, obj.y - 1));  // 1  , - 1 
    }

}
