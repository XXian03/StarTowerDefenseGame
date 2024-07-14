using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[System.Serializable]
public class Entity : MonoBehaviour, IPointerExitHandler
{
    public Stats EntityStats;
    private protected SpriteRenderer entitySr;
    public Item ItemOnHeld;
    public GameObject TextDisplayer;
    public List<GridObject> AttackingRange; // Use this to hold the GridObject as a list to keep track the Attacking Range 
    public GridObject gridObject;

    public GameObject ParentBox; // Use to get the parentbox for containning all the area square;
    public List<Sprite> Idle;

    private int currentframe;

    private float AnimationTimer;
    public float SetTimer; // this is used here for easy adjusting numbers

    private float AttackTimer;





    public virtual void Start()
    {
        entitySr = GetComponent<SpriteRenderer>();
        SwitchUiOff();
        currentframe = 0;

        CreateAttackArea();
        CreateAttackAreaDisplay();

        SetTimer = 1f;
        AnimationTimer = SetTimer;


        AttackTimer = EntityStats.AtkSpd; // this enitity's attack timer is based on the entity's atk spd 

        ShowAttackGrid();

    }
    public void Update()
    {
        AnimationTimer -= Time.deltaTime;
        AttackTimer -= Time.deltaTime;


        entitySr.sprite = Idle[currentframe]; // always check the frame now

        if (AnimationTimer <= 0) // timer reduce to 0
        {
            AnimationTimer += SetTimer;  // reset timer
            currentframe += 1;
        }

        if (currentframe > Idle.Count - 1)
        {
            currentframe = 0;
        }



        if (AttackTimer <= 0)
        {
           for (int i = 0; i < AttackingRange.Count; i++)
            {
                if (AttackingRange[i].HasEnemy())
                {
                    Attack(i);
                    AttackTimer = EntityStats.AtkSpd;
                }
                else
                {
                    AttackTimer = EntityStats.AtkSpd;
                }

            }
        }
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
     //   ParentBox.SetActive(true);
    }

    public virtual void SwitchUiOff()
    {
        TextDisplayer.SetActive(false);
        // ParentBox.SetActive(false);
    }

    public void CreateAttackArea() // obj is character 
    {
        if (AttackingRange == null)
        {
            AttackingRange = new List<GridObject>(); // create a new list to hold all the Attacking Grids (GridObject)
        }

        // add the main grid's grid object not create new grid 

        // atkGrid add based on obj's x and y
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x - 1, gridObject.y + 1));  // -1 , 1
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x, gridObject.y + 1));  // 0  , 1  
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x + 1, gridObject.y + 1));  // 1  , 1  

        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x - 1, gridObject.y));      // -1 , 0
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x, gridObject.y));      //  0 , 0
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x + 1, gridObject.y));      //  1 , 0 

        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x - 1, gridObject.y - 1));   // -1 , - 1 
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x, gridObject.y - 1));   // 0  , - 1  
        AttackingRange.Add(Game.Instance.GetMainGridGridObject(gridObject.x + 1, gridObject.y - 1));   // 1  , - 1 
    }

    public void CreateAttackAreaDisplay()
    {
        for (int i = 0; i < AttackingRange.Count; i++)
        {
            GameObject a =  Instantiate(GameAsset.GetInstance().AreaSquare, new Vector3(this.gridObject.x, this.gridObject.y, 0), Quaternion.identity);
            a.transform.SetParent(ParentBox.transform);
        }
    }

    public void ShowAttackGrid () // use for getting attackgrid for this entity
    {
        for (int i = 0; i < AttackingRange.Count; i++)
        {
            Debug.Log(AttackingRange[i].x + "," + AttackingRange[i].y);
        }
    }


    public void GetIdleFrames (List<Sprite> _idle)
    {
        Idle = _idle;
    }

    public void GetGridObject(GridObject _gridObject)
    {
        gridObject = _gridObject;
    }
   
    public void SetParentBox(GameObject _parent)
    {
        ParentBox = _parent;
    }

    public void SetTextDisplayer(GameObject gameObj)
    {
        TextDisplayer = gameObj;
    }

    public void Attack(int x)
    {
        AttackingRange[x].EnemyOnGrid.EnemyStats.TakeDamage(EntityStats.Atk);
    }


   

    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int x;
        int y;

        for (x = 0; x < AttackRange.width ; x++)
        {
            for (y = 0; y < AttackRange.height; y++)
            {
                collision.GetComponent<Enemy>().EnemyStats.TakeDamage(EntityStats.Atk);
            }
        }
    }
    */


    public void OnPointerExit(PointerEventData eventData)
    {
       // SwitchUiOff();
    }
}
