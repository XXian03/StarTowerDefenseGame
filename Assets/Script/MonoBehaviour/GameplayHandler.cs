using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayHandler : MonoBehaviour
{

    [SerializeField] DeckHandler deckHandler;

    void Start()
    {
       

        
        
    }

    void Update()
    {
        if (Game.Instance.GameState != GameStateEnum.GameplayPhase)
        {
            return;
        }

        int x;
        int y;
        
        Game.Instance.GetMainGrid().GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
        // Take the clicked position and turn it in to whole number first;

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if(Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid != null)
            {
                Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid.CallTowerFunction();
                // From MainGame --> Get MainGrid ' s --> GridObject xy (which is what you selected) --> The thing on the grid's --> CallTowerFunction;    
            }
            
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            Game.Instance.GameState = GameStateEnum.DrawPhase;
            deckHandler.Maindeck.DealThreeCards();
            deckHandler.ReDealTimes = 2;
        }

    }
}
