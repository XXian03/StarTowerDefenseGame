using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card 
{
    public int Id;
    public string Name;
    public int Price;
    public string Description;
    public CardType CardType;
    public Rarity CardRarity;
    public Sprite CardVisual;
    public int Quantity;
    


    public Card (int _id ,string _name , int _price , string _description, Sprite _cardVisual, CardType _cardType, Rarity _rarity)
    {
        Id = _id;
        Name = _name;
        Price = _price;
        Description = _description;
        CardVisual = _cardVisual;
        CardType = _cardType;
        CardRarity = _rarity;
    }

    public Card (Card card)  // Clonning a new card with same stats, (Preventin loss from the base data) 
    {
        Id = card.Id;
        Name = card.Name;
        Price = card.Price;
        Description = card.Description;
        CardVisual = card.CardVisual;
        CardType = card.CardType;
        CardRarity = card.CardRarity;
    }
    public Card Clone() // do the same thing on top , but less felxiable and less word;
    {
        return new Card(this);
    }






}
