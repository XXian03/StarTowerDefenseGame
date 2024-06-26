using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    public GameStateEnum GameState;   // Basically same as Game State , but is easier to Reference compare to Int numbers
    [SerializeField] Transform GridParent; // Use this to hold all the instantiate object
    [SerializeField] DeploymentBrush deploymentBrush;

    [SerializeField] UiHandler ui;
    private FakeGrid mainGrid; // Is a class , inside holds 5 important variables
    // Width , Height, GridObject , Cellsize , OriginPosition 
      // Inside GridObject there is another 6 variables on to it 
           // x , y , Sr , Tmp , TileEnum , TileType (don't care this part first until the top part resolved)

    // Singleton 
    private static Game instance; 
    public static Game Instance => instance;




    private void Awake()
    {
        if (instance == null)  // if there is no instance 
        {
            instance = this; // instance will become this 
        }
        else
        {
            Destroy(gameObject); // or else destroy this object;
                                 // The reason would also because of preventing singleton easily get reference 
                                 // and potiential destroying the whole project
        }
    }


    void Start()
    {
        StartGame(); // Main Grid become the Json File in the GameAsset slotted in to; 



    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            
        }

        ui.DebugCanDeploy.text = deploymentBrush.CanDeploy.ToString();



        if (GameState != GameStateEnum.DrawPhase)
        {
            ui.TextBox_0.SetActive(false);
            ui.TextBox_1.SetActive(false);
            ui.TextBox_2.SetActive(false);
            ui.CardPhaseUI.SetActive(false);
            ui.Card_0.SetActive(false);
            ui.Card_1.SetActive(false);
            ui.Card_2.SetActive(false);
            
        }
        else
        {
            ui.CardPhaseUI.SetActive(true);
            ui.Card_0.SetActive(true);
            ui.Card_1.SetActive(true);
            ui.Card_2.SetActive(true);
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
           
        }    

    }


    private void StartGame()
    {
        mainGrid = LevelConverter.instance.LoadJsonFile(GameAsset.GetInstance().FarmStage_1, new GameObject() , GridParent);
        // MainGrid will get "Data" from the text files(json) , to slot in the 5 variables on top
        // Meanwhile Create the Grid through "LevelConverter's --> LoadJsonFile()" function;

        // private FakeGrid mainGrid is to reference inputs 
        // while Text files(json) is to reference as "data"(int(s) and string(s)) into the inputs
        
        GameState = GameStateEnum.DrawPhase; // GameState 1
    }


    public FakeGrid GetMainGrid()  // A fuction to get private "mainGrid" , so it will prevent get affected  
    {
        return mainGrid;
    }



}
