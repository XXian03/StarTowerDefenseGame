using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public List<Food> AllFoodInGame;
    private static ItemDataBase instance;
    public static ItemDataBase Instance => instance;
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
    
    public void InitializeItemList()
    {
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
    }





}
