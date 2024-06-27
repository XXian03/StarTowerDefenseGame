using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public Stats EnemyStats; // Stats for the deployed enemy
    private protected SpriteRenderer enemySr; // it's sprite renderer
    public FakeGrid AttackRange; // the attacking range 

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
