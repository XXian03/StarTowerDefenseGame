using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDataBase : MonoBehaviour
{
    public List<Food> AllFoodInGame;
    private static FoodDataBase instance;
    public static FoodDataBase Instance => instance;
    public void Awake()
    {
        instance = this;
    }


    void Start()
    {
        InitializeFoodList();
    }

    void Update()
    {
        
    }
    
    public void InitializeFoodList()
    {
        AllFoodInGame = new List<Food>()
        {
            new Food(
                100 , "Sunny Side Egg" ,
            (GridObject gridObj)=>
            { Debug.Log($"{gridObj.EntityOnGrid.EntityStats.Name} has gain Atk + 3"); gridObj.EntityOnGrid.EntityStats.Atk += 3; }
            ),
            
            new Food(
                101 , "Ramen" , 
            (GridObject gridObj)=>
           { Debug.Log($"{gridObj.EntityOnGrid.EntityStats.Name} has gain Atk + 2"); gridObj.EntityOnGrid.EntityStats.Atk += 2; }
            ),

            new Food(
                102 , "Sandwich", 
            (GridObject gridObj)=> 
            Debug.Log($"{gridObj.EntityOnGrid.EntityStats.Name} has Eat A Sandwhich")
            )
        };
    }





}

/*
       AllFoodInGame = new List<Food>()
        {
            new Food(
                101 , "Sunny Side Egg" , 
            (Food item)=>
            Debug.Log($"{item.GridObject.EntityOnGrid.name} has gain Atk + 3")
            ),
            
            new Food(
                102 , "Ramen" , 
            (Food item)=>
            Debug.Log($"{item.GridObject.EntityOnGrid.name} has gain Hp + 2")
            ),

            new Food(
                103 , "Sandwich", 
            (Food item)=> 
            Debug.Log($"{item.GridObject.EntityOnGrid.name} has Eat A Sandwhich")
            )
        };
 */