using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentManager : MonoBehaviour
{
    [SerializeField] DeploymentBrush brush; // Referecing Brushes
    private Game gameHandler;        // Refrencing GameHandler
    public int SelectionState;    // Using for changing Selection Stage 
    /* 
     * 0 - No Character
     * 1 - Star 
     */

    [SerializeField] DeckHandler deckHandler;

    private void Awake()
    {
        gameHandler = Game.Instance;
    }

    void Start()
    {
        
    }



    void Update()
    {
        if(Game.Instance.GameState == GameStateEnum.GameplayPhase)
        {
            // I can activate item's effect 
        }
    
    }

    public void SetTower(GridObject objToSetIn , Entity entity)
    {
        objToSetIn.SetEntity(entity);
    }
    public void SummonTowerOnBoard()
    {

        DeploymentData data = brush.CheckDeployable();
        // DeploymentData has 3 things inside, and now this Manager has a Refrence for all the 3 variables inside
        //   ---> and is referencing DeploymentBrush's CheckDeployable's data 

        if (!data.CanDeploy) // if data "cannot!" deploy  
        {
            // Debug.Log ("You cannot select this since there is no tower");
            return; // stop here go back
        }
        FakeGrid grid = Game.Instance.GetMainGrid(); // Reference the main grid 

        GridObject gridObject = grid.GetGridObject(data.XY.x, data.XY.y); // reference the grid's position (which is an object)


        GameObject obj = Instantiate(GameAsset.GetInstance().AllTowerObject[SelectionState], data.WorldPosition, Quaternion.identity);
        // Summon the tower out based on ther Selectionstage, 

        Tower tower = obj.AddComponent<Tower>();  // tower means help obj add a component, 
        tower.gameObject.AddComponent<BoxCollider2D>();
        if (data.CanDeploy == true)  // if can deploy is true
        {
            switch (SelectionState) // go through 1 of the process below (based on Selection State)
            {
                case 0:
                    tower.SetUp(new Stats("Cannon Tower", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 1:
                    tower.SetUp(new Stats("Ice Tower", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 2:
                    tower.SetUp(new Stats("Fire Tower", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 3:
                    tower.SetUp(new Stats("Bolt Tower", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 4:
                    tower.SetUp(new Stats("Wide Tower", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 5:
                    tower.SetUp(new Stats("Arrow Bolt", 3, 1f));
                    SetTower(gridObject, tower);
                    break;
                case 6:
                    tower.SetUp(new Stats("Mana Tower", 10, 1.2f));
                    SetTower(gridObject, tower);
                    break;
            }
        }


        Game.Instance.GameState = GameStateEnum.GameplayPhase;


    }
    // After Summon will jump to GameplayState //



    public void CallTowerType(int _x)
    {
        if (deckHandler.Maindeck.CardsInDeck[_x].CardType == CardType.Tower)
        {
            SelectionState = deckHandler.Maindeck.CardsInDeck[_x].Id;
            // It will go through the your maindeck and get the card 0 1 2 and have it's id to become selectionState
        }
        else
        {
            SelectionState = 101;
        }



        brush.characterSelected = 1;

        Game.Instance.GameState = GameStateEnum.DeployPhase;
        // And jump to Deploy Phase afterwards
    }
    public void ApplyItem()
    {
        DeploymentData data = brush.CheckDeployable(); // Deployment data reference you bursh position 

        FakeGrid grid = Game.Instance.GetMainGrid(); // Based on the main grid
        GridObject gridObject = grid.GetGridObject(data.XY.x, data.XY.y); // Get the data for the object where your brush is

        if (gridObject.HasEntity() == true) 
        {
           // gridObject.EntityOnGrid.
        }


    }

    
}
