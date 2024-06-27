using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsset : MonoBehaviour
{
    private static GameAsset ins; //Singleton Pattern

    // Editor mode //
    [Header("=== Ground ===")]
    public Sprite Ground_1;
    public Sprite Ground_2;
    public Sprite Ground_3;
    public Sprite Ground_4;
    public Sprite Ground_5;
    public Sprite Ground_6;
    public Sprite Ground_7;
    public Sprite Ground_8;
    public Sprite Ground_9;
    public Sprite Ground_10;
    [Header("=== Water ===")]
    public Sprite Water_1;
    public Sprite Water_2;
    public Sprite Water_3;
    public Sprite Water_4;
    public Sprite Water_5;
    [Header("=== Grass ===")]
    public Sprite Grass_1;
    public Sprite Grass_2;
    public Sprite Grass_3;
    [Header("=== Tree_1 ===")]
    public Sprite Tree_1;
    public Sprite Tree_2;
    public Sprite Tree_3;
    public Sprite Tree_4;
    public Sprite Tree_5;
    public Sprite Tree_6;
    [Header("=== Fence ===")]
    public Sprite Fence_1;
    public Sprite Fence_2;
    public Sprite Fence_3;
    public Sprite Fence_4;
    public Sprite Fence_5;
    public Sprite Fence_6;
    [Header("=== HighGround ===")]
    public Sprite HighGround_1;
    public Sprite Highground_2;
    [Header("=== Stump ===")]
    public Sprite Stump_1;
    [Header("=== Enter + Exit ===")]
    public Sprite Enter_1;
    public Sprite Enter_2;
    public Sprite Exit_1;

    [Header("=== Area Square ===")]
    public Sprite AreaSquare;

    [Header("=== Stage To Load ===")]
    public TextAsset FarmStage_1; // Easy to Change Stage in the future 



    // GamePlay Scene //

    [Header("=== CharacterSprites ===")]
    public Sprite Star; // calling Star

    [Header("=== TowerType GameObject ===")]
    public GameObject TowerTypeStar;
    public GameObject TowerTypeCannon;
    public GameObject TowerTypeIceTower;
    public GameObject TowerTypeFireTower;
    public GameObject TowerTypeBoltTower;
    public GameObject TowerTypeManaTower;

    public List<GameObject> AllTowerObject;



    [Header("=== EnemyType GameObject ===")]
    public GameObject EnemySlime;
    public GameObject EnemyBunnySlime;
    public GameObject EnemySwordSlime;

    public List<GameObject> AllEnemy;



    [Header("=== SummonType ===")]
    public Sprite StarKnight;
    public Sprite NeptuneDragon;



    [Header("=== TowerType ===")]
    public Sprite Cannon;
    public Sprite IceTower;
    public Sprite FireTower;
    public Sprite BoltTower;
    public Sprite WideCannon;
    public Sprite ArrowBolt;
    public Sprite ManaTower;

    [Header("=== FoodType ===")]
    public Sprite SunnySideEgg;
    public Sprite Ramen;
    public Sprite Sandwich;

    [Header("=== ItemType ===")]
    public Sprite Dynamite;
    public Sprite AmuletCoin;
    public Sprite RedCape;
    public Sprite SpeedUpBoots;
    public Sprite UltimateArmour;
    public Sprite Bomb;


    [Header("=== Card UI ===")]
    public Sprite CardFrame;
    public Sprite NomralIcon;
    public Sprite RareIcon;
    public Sprite SuperRareIcon;
    public GameObject TowerStatsTextBox;

    public List<Sprite> AllCardVisual;

    public GameObject ParentBox;


    [Header("=== Enemy Sprite ===")]
    public Sprite Slime;
    public Sprite BunnySlime;
    public Sprite SwordSlime;

    public List<Sprite> AllEnemySprite;



    [Header("=== Tower Animation ===")]

    public List<List<Sprite>> AllListIdle;

    [SerializeField] List<Sprite> CannonIdle;
    [SerializeField] List<Sprite> IceTowerIdle;
    [SerializeField] List<Sprite> FireTowerIdle;


    [Header("=== Parent Boxes ===")]
    [SerializeField] public GameObject GridParent;


    [Space]
    [Space]
    [Space]

    public List<Sprite> GroundSet;
    public List<Sprite> WaterSet;
    public List<Sprite> FenceSet;







    void Start()
    {
        GroundSet = new List<Sprite>
        {
            Ground_1,
            Ground_2,
            Ground_3,
        };
        WaterSet = new List<Sprite>
        {
            Water_1,
            Water_2,
            Water_3,
        };
        FenceSet = new List<Sprite>
        {
            Fence_1,
            Fence_2,
            Fence_3,
        };

        AllTowerObject = new List<GameObject>
        {
            TowerTypeCannon,   
            TowerTypeIceTower,
            TowerTypeFireTower,
            TowerTypeBoltTower,
            TowerTypeStar,   // placeholder
            TowerTypeStar,   // placeholder
            TowerTypeManaTower,            
        };


        AllEnemy = new List<GameObject>
        {
            EnemySlime,
            EnemyBunnySlime,
            EnemySwordSlime,
        };

        AllEnemySprite = new List<Sprite>
        {
            Slime,
            BunnySlime,
            SwordSlime,
        };




        AllListIdle = new List<List<Sprite>>
        {
            CannonIdle,
            IceTowerIdle,
            FireTowerIdle,
        };







        AllCardVisual = new List<Sprite>
        {
            Cannon,
            IceTower,
            FireTower,
            BoltTower,
            WideCannon,
            ArrowBolt,
            ManaTower,
            SunnySideEgg,
            Ramen,
            Sandwich,
            Dynamite,
            Bomb
            // Continue Later 

        };




    }

    void Update()
    {
        
    }





    public static GameAsset GetInstance()
    {
        return ins;
    }
    public void Awake()
    {
        ins = this;
    }
}
