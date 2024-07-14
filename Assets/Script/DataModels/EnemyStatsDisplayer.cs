using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStatsDisplayer : MonoBehaviour
{
    private Enemy EnemyStats;
    [SerializeField] GameObject StatsHolder;
    [SerializeField] TextMeshProUGUI text;

    void Start()
    {
        
    }

    void Update()
    {
        text.text = $"{EnemyStats.EnemyStats.Name} \nHp: {EnemyStats.EnemyStats.Hp}";
    }

    
    public void SetEnemyStats(Enemy enemy)
    {
        EnemyStats = enemy;
    }

}
