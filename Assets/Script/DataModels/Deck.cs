using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck
{
    public List<Card> CardsInDeck;
    public List<Card> DealtCards;
    public List<Card> Grave;
    public List<Card> RemoveFromPlay;

    public Card SelectingCard;

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


    public void SelectingACard(Card card)
    {
        SelectingCard = card;
        DealtCards.Remove(card);
    }


    public void RemoveCardFromPlay ()
    {
        if (RemoveFromPlay == null)
        {
            RemoveFromPlay = new List<Card>();
        }

        RemoveFromPlay.Add(SelectingCard);
        SelectingCard = null; 
    }

    public void ReturnAllCards(int _xTimes)
    {
        for (int i = 0; i < _xTimes; i++)
        { 
            CardsInDeck.Add(Grave[0]);   // Put the card into deck   
            Grave.RemoveAt(0);      // Remove the cards from grave   
        }
    }

    public void SendCardsToGrave(int _xTimes)
    {
        if (Grave == null)
        {
            Grave = new List<Card>();
        }

        for (int i = 0; i < _xTimes; i++)
        {
            Grave.Add(DealtCards[0]); // Put the card into grave    
            DealtCards.RemoveAt(0);   // Remove the DealtCards  
           
        }
    }

    public void PrepareCardsToDeal(int _xTimes)
    {
        for(int i = 0; i < _xTimes; i ++)
        {
            DealtCards.Add(CardsInDeck[0]);
            CardsInDeck.RemoveAt(0);

            if (CardsInDeck.Count < 1)  // if my reamining cards in deck is smaller than 3 
            {
                ReturnAllCards(Grave.Count);
                ShuffleDeck();
            }

        }
    }


    public List<Card> DealThreeCards()  // Dealing 3 cards 
    {
        if(DealtCards == null)
        {
            DealtCards = new List<Card>(); // For safety purpose  
        }

       
    
        if (DealtCards.Count > 0)  // if my dealt cards is not 0
        {
            SendCardsToGrave(DealtCards.Count);  
        }


   
    

         PrepareCardsToDeal(3) ;



        return DealtCards;
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
