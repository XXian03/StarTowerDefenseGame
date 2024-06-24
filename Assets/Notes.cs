using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;
using TMPro;

/*
public class LevelConverterSample : MonoBehaviour
{
    //Receive a TextFile, Load level.
    //Receive a Level, Create Text File
    private static LevelConverter instance; //Singleton
    public static LevelConverter Instance => instance;
    private void Awake()
    {
        instance = this;
    }










    [SerializeField] string FileName; //Change the filename to save your file as different name
    [SerializeField] TextAsset levelToLoad; //this is the file you use to load

    [SerializeField] TextAsset json;  // ((Create Your JSON File here))








    public void CreateFile(FakeGridObject[,] Grid, int width, int height) //Function takes in existing grid
    {

        StringBuilder sb = new StringBuilder(); //String builder is a class that let you combine alot of string
        //sb.Append is combine string into stringbuilder
        //sb.AppendLine is combine string into a new line

        for (int x = 0; x < Grid.GetLength(0); x++)
        {
            for (int y = 0; y < Grid.GetLength(1); y++)
            {
                sb.Append($"{(int)Grid[x, y].floorTile},"); //For each x,y, combine the floorTile value into a string builder
            }
        }
        



        Debug.Log(sb.ToString()); //Show the value of string builder




        //SB is only list Of Tiles

        GridData gridData = new GridData(width, height, sb.ToString());

        string output = JsonUtility.ToJson(gridData);






        File.WriteAllText(Application.dataPath + $"{FileName}.json", output); //Save file into folders, need to Using System.IO;
        //File is the class
        //WriteAllText is the function to write all the text into a file
        //Input 1 - Application.dataPath is a string that show where you game is, example, C://Unity/Game/, + /Directory/FileName
        //Input 2 - The text you want to write.


    }

    public FakeGrid LoadFile(TextMeshProUGUI text, Transform textParent)
    {
        GridData dataToLoad = JsonUtility.FromJson<GridData>(levelToLoad.text);


        FakeGridObject[,] gridObjectArray = new FakeGridObject[dataToLoad.Width, dataToLoad.Height];
        Debug.Log(dataToLoad.Width + " " + dataToLoad.Height + " " + dataToLoad.ListOfTiles); //This is to show that we can read the file

        string[] tileData = dataToLoad.ListOfTiles.Split(","); //Create an array of string, each member is split by ,
        int number = 0; //iteration number, so each time you SetImage, you move to the next number in tileData
        //Like current Frame
        for (int x = 0; x < dataToLoad.Width; x++)
        {

            for (int y = 0; y < dataToLoad.Height; y++)
            {
                //Each Object in the array is its own instance, so you can hold any amount of data
                gridObjectArray[x, y] = new FakeGridObject(x, y);
                GameObject obj = Instantiate(text.gameObject, gridObjectArray[x, y].GetSetPosition(1, new Vector3(-15, -5)), Quaternion.identity);
                obj.transform.SetParent(textParent);
                gridObjectArray[x, y].SetGameObject(obj);
                gridObjectArray[x, y].ChangeText();
                //(TileEnum) changes int value into TileEnum
                //int.Parse changes a string into number
                //EG "1" becomes 1
                if (number < tileData.Length - 1)
                {
                    gridObjectArray[x, y].SetImage((TileEnum)int.Parse(tileData[number]));
                }
                else
                {
                    gridObjectArray[x, y].SetImage((TileEnum)0);
                }
                number++;
            }
        }

        FakeGrid output = new FakeGrid(gridObjectArray, dataToLoad.Width, dataToLoad.Height, 1, new Vector3(-15, -5));
        return output;
    }

}
/*
public class GridData
{
    public int Width;
    public int Height;
    public string ListOfTiles;

    public GridData(int width, int height, string listOfTiles)
    {
        Width = width;
        Height = height;
        ListOfTiles = listOfTiles;
    }
}
*/