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
                if (deckHandler.Maindeck.CardsInDeck[deploymentManager.SelectionState].CardType == CardType.Tower) // Summon Tower on boards and enter Gameplay
                {
                    deploymentManager.SummonTowerOnBoard(); // Jump to Gameplay State
                }
                if (deckHandler.Maindeck.CardsInDeck[deploymentManager.SelectionState].CardType == CardType.Food) // Summon Tower on boards and enter Gameplay
                {

                }
            }
        }
    }
}
