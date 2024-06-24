using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPhaseHandler : MonoBehaviour
{
    [SerializeField] CardDataBase cardDataBase;
    [SerializeField] DeckHandler deckHandler;
    [SerializeField] UiHandler uiHandler;




    void Start()
    {
        cardDataBase.InitializeList();  // Load all cards in the game 
        deckHandler.ReDealTimes = 2;    // Ready the number to redeal to 2

        uiHandler.TextBox_0.SetActive(false);  // Start game turn off the description text box
        uiHandler.TextBox_1.SetActive(false);
        uiHandler.TextBox_2.SetActive(false);
        // You can hover over the object to see display the text 
  

        deckHandler.CreateDeck();  // Start of the game create a deck
        deckHandler.Maindeck.ShuffleDeck(); // then shuffle
        deckHandler.Maindeck.DealThreeCards(); // then deal 3 cards
        // In DeckHandler has a function to ReDeal cards
    }

    void Update()
    {
        Game GH = Game.Instance;

        if(GH.GameState == GameStateEnum.DrawPhase)
        {
            // Will Display all the Ui
            uiHandler.DisplayingCardsUi();
            uiHandler.deckText.text = $"Card Remaining \n {deckHandler.Maindeck.CardsInDeck.Count.ToString()}";
            uiHandler.dealTimes.text = $"Remaing: {deckHandler.ReDealTimes}";
         
        }



    }
}
