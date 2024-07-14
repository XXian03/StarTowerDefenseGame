using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameplayHandler : MonoBehaviour,  IPointerExitHandler
{

    [SerializeField] DeckHandler deckHandler;
    [SerializeField] DeploymentManager deploymentManager; // for EnemyDbugModeUsage


    public int x;
    public int y;

   

    void Start()
    {
       

        
        
    }

    void Update()
    {
        if (Game.Instance.GameState != GameStateEnum.GameplayPhase)
        {
            return;
        }


        
        Game.Instance.GetMainGrid().GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
        // Take the clicked position and turn it in to whole number first;

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            if(Game.Instance.GetMainGrid().GridObjects[x , y].EntityOnGrid != null)
            {
                Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid.CallTowerFunction();
                // From MainGame --> Get MainGrid ' s --> GridObject xy (which is what you selected) --> The thing on the grid's --> CallTowerFunction;    
                Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid.SwitchUiOn();
            }  
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid != null)
            {
                Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid.SwitchUiOff();
            }

        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            Game.Instance.GameState = GameStateEnum.DrawPhase;
            deckHandler.Maindeck.DealThreeCards();
            deckHandler.ReDealTimes = 2;
        }



        if (Input.GetKeyDown(KeyCode.P))
        {
            Game.Instance.GameState = GameStateEnum.EnemyDebugDeploy;
            deploymentManager.SelectionId = 0;
        }

    }



    public void OnPointerExit(PointerEventData eventData)
    {

        Game.Instance.GetMainGrid().GridObjects[x, y].EntityOnGrid.SwitchUiOff();
    }
}
