using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Stats EntityStats;
    private protected SpriteRenderer entitySr;

    // 2 empty shell waiting for input
    //  - A Stats 
    //  - A Sprite


    public virtual void Start()
    {
        entitySr = GetComponent<SpriteRenderer>();
    }

    public virtual void SetUp(Stats battleStats) // Stats on this shell
    {
        EntityStats = battleStats;
    }

    public virtual void CallTowerFunction()
    {
        
    }


}
