using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;
using System.IO;

public class LevelConverter : MonoBehaviour
{
    public static LevelConverter instance; //Singleton

    [SerializeField] string FileName;
    [SerializeField] TextAsset levelToLoad;
    [SerializeField] TextAsset json;


    public void Awake()
    {
        instance = this;
    }



    // === Save Game === //
    public void CreateFile(FakeGrid fakeGridToSave) // Function to create a file of string with the current input you have applied
                                                                       // int width and height has no usage at the moment 
    {
        StringBuilder sb = new StringBuilder();  // create a new string builder 
        
        for (int x = 0; x < fakeGridToSave.GridObjects.GetLength(0); x++) // do this loop X times based on Grid 1st number 
        {
            for (int y = 0; y < fakeGridToSave.GridObjects.GetLength(1); y++) // do this loop y times based on Grid 2nd number
            {
                sb.Append($"{(int)fakeGridToSave.GridObjects[x, y].tileenum},"); // For each x,y , combine "tileenum" into a string builder
            }
        }


        GridData gridData = new GridData(fakeGridToSave.width, fakeGridToSave.height, sb.ToString(), fakeGridToSave.CellSize , fakeGridToSave.originPosition.x , fakeGridToSave.originPosition.y); // create a new GridData which holds width height and list of tiles data which turns into a bunch of numbers 
        string output = JsonUtility.ToJson(gridData); // this will compacted everything into "Json" data with strings


        File.WriteAllText(Application.dataPath + $"/SaveFile/{FileName}.json", output);
        // File is the class 
        // WriteAllText is a function to write all the text into a file 
        // 1st input "Application.dataPath" is to track your unity current folder in your pc
        // 2nd input is to add "filename" to the file you Saving; 
    }




    // === Load Game === //
    
    // For Editing Use , which contains Debug Text on it
    public FakeGrid LoadJsonFile (GameObject gObject, Transform objectParent , TextMeshProUGUI textObj ,GameObject textParent )  // input for gameobject(empty) , ObjectHolder 
    {
        // Fake Grid has 5 things 
        // width , height , GridObject with Array , cellsize , Vector3
        // The logic over here is to get "Data" for all the variables on top through this function,
        // meanwhile recreate the scene again by using the numbers in the numbers in the json file
      


        GridData dataToLoad = JsonUtility.FromJson<GridData>(json.text);  // this part is unpack the data inside json.text in to strings or numbers?
        // in this json text , there are 3 things 
        // width , height , listOfTiles


        GridObject[,] gridObjectArray = new GridObject[dataToLoad.Width, dataToLoad.Height]; 
        // First, "gridObjectArray" was newly created and import data from "dataToLoad" 
        // which is width and height 

        // Uptil this part , FakeGrid has reference for width ,height and GridObject with Array 


        Debug.Log(dataToLoad.Width + "" + dataToLoad.Height + "" + dataToLoad.ListOfTiles); // this is to debug the numbers in there make sure it load;

        string[] tiledata = dataToLoad.ListOfTiles.Split(","); // this are used to seperate the numbers in "ListOfTiles" in the json file
        
        int number = 0;

        for (int x = 0;  x < dataToLoad.Width; x++)  // first , based on dataToLoad's Width 
        {
            for (int y = 0; y < dataToLoad.Height; y++) // and dataToLoad's Height  loop the function below
            {
                gridObjectArray[x, y] = new GridObject(x, y);  // 
                GameObject obj = Instantiate(gObject, gridObjectArray[x, y].WorldPosition(dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY, 0)), Quaternion.identity);
                GameObject _text = Instantiate(textObj.gameObject, gridObjectArray[x, y].WorldPosition(dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY , 0)), Quaternion.identity); // Generate Text Object 
                _text.transform.SetParent(textParent.transform); // Set the text under gObject 
                obj.transform.SetParent(objectParent.transform);
                gridObjectArray[x, y].Sr = obj.AddComponent<SpriteRenderer>();

                gridObjectArray[x, y].SetTile((TileEnum)int.Parse(tiledata[number]));   // number is to check member 
                number++;

                _text.GetComponent<TextMeshProUGUI>().text = $"{x} , {y}";

            }
        }
        
        // right until this part, there are no way to reference Cellsize and OriginPosition due to createfile() fuction doesn't have yet
        // so number below is hardcoded
           
        FakeGrid output = new FakeGrid(dataToLoad.Width, dataToLoad.Height, gridObjectArray, dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY));
        //prepare an output here , import the data on top ("dataToLoad") into this output 
        
        return output; // and return back the output here 
    }
    // This has no DebugTmp and the text holder required (old version)//
    public FakeGrid LoadJsonFile(GameObject gObject, Transform objectParent)  
    {

        GridData dataToLoad = JsonUtility.FromJson<GridData>(json.text);  
        GridObject[,] gridObjectArray = new GridObject[dataToLoad.Width, dataToLoad.Height];
        Debug.Log(dataToLoad.Width + "" + dataToLoad.Height + "" + dataToLoad.ListOfTiles); 
        string[] tiledata = dataToLoad.ListOfTiles.Split(","); 
        int number = 0;
        for (int x = 0; x < dataToLoad.Width; x++)  
        {
            for (int y = 0; y < dataToLoad.Height; y++) 
            {
                gridObjectArray[x, y] = new GridObject(x, y);  
                GameObject obj = Instantiate(gObject, gridObjectArray[x, y].WorldPosition(dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY, 0)), Quaternion.identity); 
                obj.transform.SetParent(objectParent.transform);
                gridObjectArray[x, y].Sr = obj.AddComponent<SpriteRenderer>();
                gridObjectArray[x, y].SetTile((TileEnum)int.Parse(tiledata[number]));   
                number++;
            }
        }
        FakeGrid output = new FakeGrid(dataToLoad.Width, dataToLoad.Height, gridObjectArray, dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY));
        return output;
    }

    // For Gameplay Use , No Debug but has TextAsset 
    public FakeGrid LoadJsonFile(TextAsset _textAsset ,GameObject gObject, Transform objectParent)  
    {

        GridData dataToLoad = JsonUtility.FromJson<GridData>(_textAsset.text); 
        // Technically doing the same thing on top , except this one is direct referencing the textAsset in GameAsset
        //   --> Which might be used as a StageSelector in the future... 

        GridObject[,] gridObjectArray = new GridObject[dataToLoad.Width, dataToLoad.Height]; 
        Debug.Log(dataToLoad.Width + "" + dataToLoad.Height + "" + dataToLoad.ListOfTiles); 
        string[] tiledata = dataToLoad.ListOfTiles.Split(",");
        int number = 0;
        for (int x = 0; x < dataToLoad.Width; x++) 
        {
            for (int y = 0; y < dataToLoad.Height; y++) 
            {
                gridObjectArray[x, y] = new GridObject(x, y);  
                GameObject obj = Instantiate(gObject, gridObjectArray[x, y].WorldPosition(dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY, 0)), Quaternion.identity);
                obj.transform.SetParent(objectParent.transform);
                gridObjectArray[x, y].Sr = obj.AddComponent<SpriteRenderer>();
                gridObjectArray[x, y].SetTile((TileEnum)int.Parse(tiledata[number]));   
                number++;
            }
        }
        FakeGrid output = new FakeGrid(dataToLoad.Width, dataToLoad.Height, gridObjectArray, dataToLoad.CellSize, new Vector3(dataToLoad.PositionX, dataToLoad.PositionY));
        return output; 
    }

    public GridObject[,] LoadFile(GameObject gObject, Transform objectParent) // LoadingFile, input (gObject , your parent file to hold gObject) 
    {


        GridObject[,] output = new GridObject[18, 10]; // this one is create a 2d list of cap 

        string[] tileenum = levelToLoad.text.Split(",");  // when loading, split your text with each ,
        int number = 0;

        for (int x = 0; x < 18; x++)  // current is hard code     // bottom part is reconstruct the tile again 
        {
            for (int y = 0; y < 10; y++) // current is hard code
            {
                output[x, y] = new GridObject(x, y);
                GameObject obj = Instantiate(gObject, output[x, y].WorldPosition(1, new Vector3(-9, -5)), Quaternion.identity);
                obj.transform.SetParent(objectParent.transform);
                output[x, y].Sr = obj.AddComponent<SpriteRenderer>();

                output[x, y].SetTile((TileEnum)int.Parse(tileenum[number]));   // number is to check member 
                number++;
            }
        }


        return output;
    }












    public static LevelConverter GetInstance()
    {
        return instance;
    }


}
