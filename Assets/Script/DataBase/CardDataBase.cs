using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    private List<Card> AllCardsInGame;
    private static CardDataBase instance;
    public static CardDataBase Instnace => instance;

    public void Awake()
    {
        instance = this;
    }


    void Start()
    {

    }

    public void InitializeList() // Creating all the cards with data on it
    {
        GameAsset gA = GameAsset.GetInstance();
        AllCardsInGame = new List<Card>()
        {
            new Card(0, "Cannon Tower" , 1, "A Basic Tower" , gA.Cannon, CardType.Tower, Rarity.Normal),
            new Card(1, "Ice Tower" , 300, "A Icey Tower that will slow the enemy when damage" , gA.IceTower, CardType.Tower, Rarity.Normal),
            new Card(2, "Fire Tower" , 300, "A Fire Tower that will have enemy taking damage consecutive" , gA.FireTower, CardType.Tower, Rarity.Rare),
            new Card(3, "Bolt Tower" , 300, "A " , gA.BoltTower, CardType.Tower, Rarity.Normal),
            new Card(4, "Wide Cannon" , 250, "A " , gA.WideCannon, CardType.Tower, Rarity.Normal),
            new Card(5, "Arrow Bolt" , 500, "A " , gA.ArrowBolt, CardType.Tower, Rarity.Rare),
            new Card(6, "Mana Tower" , 1000, "A " , gA.ManaTower, CardType.Tower, Rarity.SuperRare),
            new Card(100, "SunnySideEgg" , 100, "A " , gA.SunnySideEgg, CardType.Food, Rarity.Normal),
            new Card(101, "Ramen" , 300, "Seems Like Soup A Ramen \n+10 Atk " , gA.Ramen, CardType.Food, Rarity.Rare),
            new Card(102, "Sandwich" , 300, "Usually Breakfast \n+3 Atk Spd " , gA.Sandwich, CardType.Food, Rarity.Rare),
            new Card(200, "Dynamite" , 100, "One time use, it dealts an Aoe damage to enemy who in Range" , gA.Dynamite, CardType.Item, Rarity.Normal),
            new Card(201, "Amulet Coin" , 1000, "Gain extra coins by killing enemy" , gA.AmuletCoin, CardType.Item, Rarity.SuperRare),
            new Card(202, "Red Cape" , 500, "Allow character dealt extra fire damage" , gA.RedCape, CardType.Item, Rarity.Rare),
            new Card(203, "Speed Up Boots" , 1200, "Grant extra speed when equipped" , gA.SpeedUpBoots, CardType.Item, Rarity.SuperRare),
            new Card(204, "Ultimate Armour" , 25000, "The most powerful armour in the game" , gA.UltimateArmour, CardType.Item, Rarity.UltraRare),
            new Card(205, "Bomb" , 30, "Dealt a 3X3 damage on nearby enemy, will be removed once used" , gA.Bomb, CardType.Item, Rarity.UltraRare),
            new Card(300, "StarKnight" , 1, "Star's Partner Summon" , gA.StarKnight, CardType.Summon, Rarity.SummonRare),
            new Card(301, "NeptuneDragon" , 1, "Neptune's Partner Summon" , gA.StarKnight, CardType.Summon, Rarity.SummonRare),
        };
    }

    public Card GetCard(int id) // this is to get the cards info in the list on top
    {
        for(int i = 0; i < AllCardsInGame.Count; i++)
        {
            if (AllCardsInGame[i].Id == id)
            {
                return AllCardsInGame[i];
            }
        }
        return null;
    }

}
