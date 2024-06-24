using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHandler : MonoBehaviour
{
    [SerializeField] public Deck Maindeck;
    public Deck CardsDealt; //Use this to contain the cards that have dealt (but currently is not being used)
    public int ReDealTimes; // how many times you can redeal


    public void CreateDeck()
    {
        Maindeck = new Deck();  // Currently 16 card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(0)); // Tower //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(0)); //   |   //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(0));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(1));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(1));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(1));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(2));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(2));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(3));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(3));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(6));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(6)); //    |   //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(6)); // ====== //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(102)); // Food Card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(102)); // Food Card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(103)); // Fodd Card

    }
    public void DealThreeCardsFromMainDeck() // for button used at the moment
    {
        if (ReDealTimes > 0)
        {
            Maindeck.DealThreeCards();
            ReDealTimes -= 1;
        }
    }

}
