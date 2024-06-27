using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Tower : Entity
{
    
 

 

    public override void CallTowerFunction()
    {
        Debug.Log($"My name is {EntityStats.Name}");
        if(ItemOnHeld != null)
        {
            ItemOnHeld.ItemEffect();
        }
    }


}
