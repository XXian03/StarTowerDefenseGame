using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DeckHandler : MonoBehaviour
{
    [SerializeField] public Deck Maindeck;
    public int ReDealTimes; // how many times you can redeal


    public void CreateDeck()
    {
        Maindeck = new Deck();  // Currently 16 card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(0)); // Tower //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(1)); //   |   //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(2));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(200));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(201));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(5));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(101));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(102));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(1));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(203));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(3));
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(4)); //    |   //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(5)); // ====== //
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(101)); // Food Card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(101)); // Food Card
        Maindeck.AddCard(CardDataBase.Instnace.GetCard(102)); // Fodd Card

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
