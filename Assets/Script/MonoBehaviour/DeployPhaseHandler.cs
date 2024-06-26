using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeployPhaseHandler : MonoBehaviour
{
    [SerializeField] DeckHandler deckHandler;
    [SerializeField] DeploymentManager deploymentManager;

    void Start()
    {
        
    }

    void Update()
    {


        // Player Controls //
        if (Game.Instance.GameState == GameStateEnum.DeployPhase) //During Deploy phase 
        {
            if (Input.GetMouseButtonDown(0)) // if press Mouse Left Click
            {
                if(deckHandler.Maindeck.SelectingCard.CardType == CardType.Tower)
                {
                    deploymentManager.SummonTowerOnBoard(); // Jump to Gameplay State
                    
                }
               else if(deckHandler.Maindeck.SelectingCard.CardType == CardType.Item)
                {
                    deploymentManager.GiveItem();
                }
                else if (deckHandler.Maindeck.SelectingCard.CardType == CardType.Food)
                {
                    deploymentManager.UseFood();
                }


            }
        }
    }
}
