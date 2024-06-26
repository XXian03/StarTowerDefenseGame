using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentManager : MonoBehaviour
{
    [SerializeField] DeploymentBrush brush; // Referecing Brushes
    private Game gameHandler;        // Refrencing GameHandler
    public int SelectionId;    // Using for changing Selection Stage 
    /* 
     * 0 - No Character
     * 1 - Star 
     */

    [SerializeField] DeckHandler deckHandler;
    [SerializeField] UiHandler uiHandler;

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


        GameObject obj = Instantiate(GameAsset.GetInstance().AllTowerObject[SelectionId], data.WorldPosition, Quaternion.identity);
        // Summon the tower out based on ther SelectionId (in this case is only 0 -> 99 )
       
        GameObject _textbox = Instantiate(GameAsset.GetInstance().TowerStatsTextBox, data.WorldPosition, Quaternion.identity);
       // Create a box on the position of the tower

        _textbox.transform.SetParent(uiHandler.StatsTextBoxHolder.transform); 
        // Set the text box as child of the StatsTextBoxHolder so that canvas display the ui
        
        Tower tower = obj.AddComponent<Tower>();  
        // tower Get a Component of tower 

        tower.gameObject.AddComponent<BoxCollider2D>();
        // And also get a boxCollider2D for pressing 

        if (data.CanDeploy == true)  // if can deploy is true
        {
            switch (SelectionId) // go through 1 of the process below (based on Selection State)
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
        deckHandler.Maindeck.RemoveCardFromPlay();

        _textbox.GetComponent<StatsDisplayer>().SetEntityOnDisplayer(tower.GetComponent<Tower>());
        // text will get it's StatsDisplayer's SetEntityOnText  

        tower.SetTextDisplayer(_textbox);
        //_textbox take the statsDisplayer on Entity and set it to himself


        Game.Instance.GameState = GameStateEnum.GameplayPhase;


    }
    // After Summon will jump to GameplayState //

    public void GiveItem()
    {
        DeploymentData data = brush.CheckDeployable();
        if (!data.CanDeploy)
        { 
            return; // stop here go back
        }

        FakeGrid grid = Game.Instance.GetMainGrid();
        GridObject gridObject = grid.GetGridObject(data.XY.x, data.XY.y);

        if (gridObject.HasEntity() == true) 
        {
            gridObject.EntityOnGrid.ItemOnHeld = ItemDataBase.Instance.AllItemInGame[deckHandler.Maindeck.SelectingCard.Id - 200]; // thinking a way to choose id instead
            Debug.Log(gridObject.EntityOnGrid.EntityStats.Name + " Got " + gridObject.EntityOnGrid.ItemOnHeld.Name);
            Game.Instance.GameState = GameStateEnum.GameplayPhase;
        }

    }
    // After Giving Item will jump to GameplayState //

    public void UseFood()
    {
        DeploymentData data = brush.CheckDeployable();
        if (!data.CanDeploy)
        {
            return; // stop here go back
        }

        FakeGrid grid = Game.Instance.GetMainGrid();
        GridObject gridObject = grid.GetGridObject(data.XY.x, data.XY.y);


        if (gridObject.HasEntity() == true)
        {
            FoodDataBase.Instance.AllFoodInGame[deckHandler.Maindeck.SelectingCard.Id - 100].FoodEffects(gridObject);
            Debug.Log(gridObject.EntityOnGrid.EntityStats.Name + "Ate" + FoodDataBase.Instance.AllFoodInGame[deckHandler.Maindeck.SelectingCard.Id - 100].Name);
            Game.Instance.GameState = GameStateEnum.GameplayPhase;


        }

    }




    public void CallTowerType(int _x)
    {

        SelectionId = deckHandler.Maindeck.DealtCards[_x].Id;
        deckHandler.Maindeck.SelectingACard(deckHandler.Maindeck.DealtCards[_x]);


        brush.SelectionState = 1; // Change the brush state to can brush

       

       

        Game.Instance.GameState = GameStateEnum.DeployPhase;
        // And jump to Deploy Phase afterwards
    }
    // This is for UI Button use , will give selection id a number based on the cards you picked 

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
