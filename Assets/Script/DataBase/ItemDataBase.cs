using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{

    public List<Item> AllItemInGame;
    private static ItemDataBase instance;
    public static ItemDataBase Instance => instance;
    public void Awake()
    {
        instance = this;
    }


    void Start()
    {
        InitializedItemList();
    }

    void Update()
    {
        
    }

    public void InitializedItemList()
    {
        GameAsset gA = GameAsset.GetInstance();
        AllItemInGame = new List<Item>()
        {
            new Item(200,"Dynamite", 
            "One time use, it dealts an great amount of Aoe damage to enemy who is in Range", gA.Dynamite,
            ()=> Debug.Log("Enemy on range Kaboom") ),
            
            new Item(201,"Amulet Coin", 
            "Gain extra coins by killing enemy" , gA.AmuletCoin,
            ()=> Debug.Log("I got alot of coins")),
            
            new Item(202,"Red Cape", 
            "Dealt Extra Fire Damage on Enemies" , gA.RedCape,
            ()=> Debug.Log("I got alot of coins")),
            
            new Item(203,"Speed Up Boots", 
            "Gain extra Atk Spd" , gA.SpeedUpBoots,
            ()=> Debug.Log("I am moving faster")),
            
            new Item(204,"Ultimate Armour", 
            "The Ultimate Aromur" , gA.UltimateArmour,
            ()=> Debug.Log("Ulti")),
            
            new Item(205,"Bomb", 
            "One time use, dealts an small Aoe damage to enemy who is in Range" , gA.Bomb,
             ()=> Debug.Log("Small Kaboom")),
        };
    }


}
