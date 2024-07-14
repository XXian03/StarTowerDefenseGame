using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntityStatsDisplayer : MonoBehaviour
{
    public Entity TextBoxEntity;
    [SerializeField] public GameObject textDisplayer;
    [SerializeField] Image box;
    [SerializeField] public TextMeshProUGUI text;


    void Start()
    {
         
    }

    void Update()
    { 
        text.text =$"{TextBoxEntity.EntityStats.Name.ToString()} \n {TextBoxEntity.EntityStats.Atk.ToString()}";
    }


    public void SetEntityOnDisplayer(Entity entity)
    {
        TextBoxEntity = entity;
    }

}
