using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPatternDataBase : MonoBehaviour
{
    public List<FakeGrid> AllAreaSquare;
    [SerializeField] GameObject gObject;

    private static GridPatternDataBase instance;
    public static GridPatternDataBase Instance => instance;

    public void Awake()
    {
        instance = this;   
    }



    void Start()
    {
        InitializeAreaSquareList();

       // CreateStraightGrid(AllAreaSquare[0]);

    }

    void Update()
    {
        
    }



    public void CreateAreaSquare(FakeGrid output , GameObject parent, Vector3 pos) // this will be the list you putted in 
    {
        // Create the area Square grid out based on what you input ontop 
        output.GridObjects = new GridObject[output.width, output.height];

        int x; // is an addative number to create new gObject on Grid since width and height only deicided the max 
        int y;

        for (x = 0; x < output.GridObjects.GetLength(0); x++)
        {
            for (y = 0; y < output.GridObjects.GetLength(1); y++)
            {
                output.GridObjects[x , y] = new GridObject(x, y);
                GameObject obj = Instantiate(gObject, output.GridObjects[x, y].WorldPosition(output.CellSize, new Vector3(pos.x - 1.5f , pos.y - 1.5f , 0)), Quaternion.identity);
                obj.GetComponent<SpriteRenderer>().sprite = GameAsset.GetInstance().AreaSquare;
                obj.GetComponent<SpriteRenderer>().color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 0.3f);
                obj.transform.SetParent(parent.transform); 
            }
        }
    }

    public void CreateStraightGrid(FakeGrid output)
    {
        int x;
        int y;


        for (x = 0; x < output.GridObjects.GetLength(0); x++)
        {
            output.GridObjects[x, 0] = new GridObject(x, 0);
            GameObject obj = Instantiate(gObject, output.GridObjects[x , 0].WorldPosition(output.CellSize, output.originPosition), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = GameAsset.GetInstance().AreaSquare;
            obj.GetComponent<SpriteRenderer>().color = new Color(Color.blue.r, Color.blue.g, Color.blue.b, 0.3f);

        }
        
    }




    public void InitializeAreaSquareList()
    {
        AllAreaSquare = new List<FakeGrid>
        {
            new FakeGrid (3, 3, 1, new Vector3(0 , 0)),
            new FakeGrid (4, 2, 1, new Vector3(0 , 0)),
        };
    }



}
