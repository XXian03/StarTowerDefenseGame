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
    public FakeGrid AttackRange;

    public GameObject ParentBox; // Use to get the parentbox for containning all the area square;

    public List<Sprite> Idle;

    private int currentframe;

    private float Timer;
    public float SetTimer; // this is used here for easy adjusting numbers

    // 2 empty shell waiting for input
    //  - A Stats 
    //  - A Sprite



    // maybe has a function to set
    // the stats displayer here when depoly on deploy manager?

    public virtual void Start()
    {
        entitySr = GetComponent<SpriteRenderer>();
        SwitchUiOff();
        currentframe = 0;


        SetTimer = 1f;
        Timer = SetTimer;

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
        ParentBox.SetActive(true);
    }

    public virtual void SwitchUiOff()
    {
        TextDisplayer.SetActive(false);
        ParentBox.SetActive(false);
    }

    public virtual void DisplayStats()
    {

    }


    public void GetAttackGrid (FakeGrid output)
    {
        AttackRange = output;
    }


    public void GetIdleFrames (List<Sprite> _idle)
    {
        Idle = _idle;
    }


    public void SetParentBox(GameObject _parent)
    {
        ParentBox = _parent;
    }



    public void SetTextDisplayer(GameObject gameObj)
    {
        TextDisplayer = gameObj;
    }




    public void Update()
    {
        Timer -= Time.deltaTime;

        entitySr.sprite = Idle[currentframe]; // always check the frame now

        if (Timer <= 0) // timer reduce to 0
        {
            Timer += SetTimer;  // reset timer
            currentframe += 1;
        }

        if (currentframe > Idle.Count -1 )
        {
            currentframe = 0;
        }

        

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SwitchUiOff();
    }
}
