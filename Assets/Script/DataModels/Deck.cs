using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<Card> CardsInDeck;

    public Deck()
    {
        CardsInDeck = new List<Card>();  // Create a new list 
    }
    public void LoadDeck(List<Card> cards)  //A Shell for you to put your deck into it, (currently is empty)  
    {
        CardsInDeck = cards;
        for (int i = 0; i < CardsInDeck.Count; i++)
        {
            Debug.Log(CardsInDeck[i].Name);
        }
    }

    public void AddCard (Card card)  // Function to add new card 
    {
        if(CardsInDeck == null)  // this will check does your list is empty so it won't conflict 
        {
            CardsInDeck = new List<Card>();
        }
        CardsInDeck.Add(card);
    }

    public void RemoveCard (Card card) // Function to remove a card 
    {
        if (CardsInDeck == null)
        {
            CardsInDeck = new List<Card>();
        }
        CardsInDeck.Remove(card);
    }

    public List<Card> DealThreeCards()  // Dealing 3 cards 
    {
        List<Card> cardsToDeal = new List<Card>()  //Create a new list 
        {
            CardsInDeck[0],   // Pulling 3 cards out in the deck , since is shuffled at the start the cards that came out will be inconsistent
            CardsInDeck[1],
            CardsInDeck[2],
        };

        RemoveCard(CardsInDeck[0]);  // once go through add the cards, remove it from the list so it won't dupe
        RemoveCard(CardsInDeck[1]);
        RemoveCard(CardsInDeck[2]);

        return cardsToDeal;
    }

    public void ShuffleDeck() 
    {
        System.Random rng = new System.Random(); // start a new rng system
        int n = CardsInDeck.Count;  // First check currently how many cards in deck,

        while (n > 1)  // if the card count is more than 1 
        {
            n--; // repeate the process below until it reached 1
            int k = rng.Next(n); // "k" is equal to the range of  0 to n(which is the CardsInDeck.Count)   
                                     // k became a random number   

            Card value = CardsInDeck[k];  // find the card in this position 

            CardsInDeck[k] = CardsInDeck[n]; //if n 20 and k is 15 , then card 20 is now card 15

            CardsInDeck[n] = value; // [15] = [20] 
        }

       // for (int i = 0; i < CardsInDeck.Count; i++)  // This is meant to debug the spawn cards but currently disable first
        {
           // Debug.Log(CardsInDeck[i].Name);
        }

    }


}
