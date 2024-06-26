using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentBrush : MonoBehaviour
{
    [Header("Debug")]
    public int SelectionState;   // This is just a state for brush to show what can display
                                        // If 0 -- nothing will display , if  1 -- diplay the brush 
    private Game gameHandler; // This is mainly used for Referencing gameHandler
                                     // so you will be able to used gameHandler as a middle man to travel to other function
                                     // Current is just "FakeGrid"(which get all the data)   or    "FakeGrid" ---> "GridObject"(which get all the functions)
    
    
    public bool CanDeploy; // Use to prevent deploying non deployable tiles 
                           // Number != 0 cannot be deployed

    [SerializeField] SpriteRenderer squareSr;    // your basic Square brush to indicate
    [SerializeField] SpriteRenderer characterSr; // hold for character sprite 

    [SerializeField] DeploymentManager deploymentManager;
    [SerializeField] DeckHandler deckHandler;

    void Start()
    {
        gameHandler = Game.Instance; // Call gameHandler instance ability;
    }

    void Update()
    {
        SelectionFuction();
    }

    private void SelectionFuction()
    {
        if(Game.Instance.GameState != GameStateEnum.DeployPhase) // if GameState not "DeployPhase"
        {
            squareSr.gameObject.SetActive(false);  // closed
            characterSr.gameObject.SetActive(false); // closed 
            return; // stop here and reutrn nothing , menaning end function 
        }

        int x;
        int y;

        FakeGrid grid = Game.Instance.GetMainGrid(); // The "grid" here == GameHandler's mainGird 
                                                            // meaning it will get all the 5 variables data due to GameHandler already have the input at void Start



        //From gameHandler
        //  ---> reference to mainGrid (through a fuction)
        //     ---> Reference to GetXY function() (due to mainGrid is a FakeGrid Class instance so it contains GetXY)  

        gameHandler.GetMainGrid().GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y); 
        // Input is based on "Main Camera's WorldPoint" and convert the numbers of x and y into a whole number 
        // Which also is the snap grid's fuction 

        
        // The "selectedObject" here is what you currently selecting (is a GridObject) 
        //    ---> and it will equals to GH.mainGrid's GridObject that get process through to rounded up becoming the whole number 
        GridObject selectedObject = gameHandler.GetMainGrid().GetGridObject(x, y);



        // The "Route" for having gameHandler as the middle man is to prevent too many direct reference so that your game will not broke easily  



        // The transform.position here is refering to Deployment Brush 
        transform.position =
            selectedObject.WorldPosition(grid.CellSize, grid.originPosition);

        //Have your Brush move towards the position of your current selecting GridObjects postion in the world 
        //  example GridObject is in [3 , 7] , you can have your brush move to [3 , 7] due to GetGridObject(x ,y)'s snap function


        // Until this part Grid's position has Resolved , part below will resolved what to do with TileType 


        if (selectedObject.TileType < 2)
        {
            TurnGreen();
            CanDeploy = true;
        }
        else
        {
            TurnRed();
            CanDeploy = false;
        }

        // Cannot Deploy
        if (SelectionState == 0)
        {
            squareSr.gameObject.SetActive(true);
            characterSr.gameObject.SetActive(false);
        }

        // Can Deploy
        if (SelectionState == 1)
        {
            characterSr.gameObject.SetActive(true);
            characterSr.sprite = deckHandler.Maindeck.SelectingCard.CardVisual;
            // Go to GameAsset and get the Art based on selectionState;            
            squareSr.gameObject.SetActive(true);
        }

    }


    // Change Color 
    private void TurnRed()
    {
        squareSr.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.3f);
    }

    private void TurnGreen()
    {
        squareSr.color = new Color(Color.green.r, Color.green.g, Color.green.b, 0.3f);
    }



    public DeploymentData CheckDeployable()
    {
        //==== Same as Selected Function ==== // 
        int x;
        int y;
        FakeGrid grid = Game.Instance.GetMainGrid(); 
        gameHandler.GetMainGrid().GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
        GridObject selectedObject = gameHandler.GetMainGrid().GetGridObject(x, y);
        //=====================================//

        // grid = GH mainGrid
        // selectedObject = the object you selecting with a snapping grid function on top

        
        if (selectedObject.HasEntity() == true &&  deploymentManager.SelectionId <= 99)  
         // if the selectedObject(which is also the Grid) got something + if it is a tower because Selection id is over 100 //  
        {
            CanDeploy = false; // then you cannot deploy;
            Debug.Log(CanDeploy);
        } 
        
      
        DeploymentData data = new DeploymentData(); // create a new deployment data 
        Debug.Log(CanDeploy);
        data.CanDeploy = CanDeploy;
        data.XY = new Vector2Int(x, y);
        data.WorldPosition = selectedObject.WorldPosition(grid.CellSize, grid.originPosition);

        return data;
    }


}
