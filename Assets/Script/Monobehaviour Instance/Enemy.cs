using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy : MonoBehaviour
{

    public Stats EnemyStats; // Stats for the deployed enemy
    private protected SpriteRenderer enemySr; // it's sprite renderer
    public FakeGrid AttackRange; // the attacking range 
    public GridObject gridObject;


    public GameObject TextDisplayer;

    void Start()
    {
        
    }

    void Update()
    {
        
        
    }


    public virtual void SetUp(Stats _enemystats)
    {
        EnemyStats = _enemystats;
    }

    
}
