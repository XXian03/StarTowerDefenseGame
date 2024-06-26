using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity : MonoBehaviour
{
    public Stats EntityStats;
    private protected SpriteRenderer entitySr;
    public Item ItemOnHeld;
   
    public GameObject TextDisplayer;

    // 2 empty shell waiting for input
    //  - A Stats 
    //  - A Sprite



    // maybe has a function to set
    // the stats displayer here when depoly on deploy manager?

    public virtual void Start()
    {
        entitySr = GetComponent<SpriteRenderer>();
        DisplayStats();
    }

    public virtual void SetUp(Stats battleStats) // Stats on this shell
    {
        EntityStats = battleStats;
    }

    public virtual void CallTowerFunction()
    {
        
    }

    public virtual void SwitchUiOn()
    {
        TextDisplayer.SetActive(true);
    }

    public virtual void SwitchUiOff()
    {
        TextDisplayer.SetActive(false);
    }

    public void SetTextDisplayer(GameObject gameObj)
    {
        TextDisplayer = gameObj;
    }


    public virtual void DisplayStats()
    {
    
    }

    public void Update()
    {
    }

}
