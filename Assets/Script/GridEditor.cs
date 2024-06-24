using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
public class GridEditor : MonoBehaviour
{
    public FakeGrid fakeGrid;
    [SerializeField] GameObject gObject;
    [SerializeField] TextMeshProUGUI text;

    [Header("======Tiles Related======")]
    [SerializeField] GameObject SquareBrush;
    [SerializeField] TileEnum tile;


    [SerializeField] Sprite placeholder;

    [SerializeField] GameObject ObjectHolder;
    [SerializeField] GameObject ObjectHolderSaved;
    [SerializeField] GameObject TextHolder;




    void Start()
    {

        fakeGrid = new FakeGrid(18, 10, 1, new Vector3(-9, -5));





    }

    void Update()
    {


        int x;
        int y;

        GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
        SquareBrush.transform.position = fakeGrid.GridObjects[x, y].SetPosition(fakeGrid.CellSize, fakeGrid.originPosition);



        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(x + "," + y);
            fakeGrid.GridObjects[x, y].ChangeImage(tile);
        }



        if (Input.GetKeyDown(KeyCode.C))
        {
            LevelConverter.GetInstance().LoadJsonFile(gObject, ObjectHolder.transform, text, TextHolder);

        }


    }



    private void GetXY(Vector3 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPosition - fakeGrid.originPosition).x / fakeGrid.CellSize); // hard code the origin postition now first? 
        y = Mathf.FloorToInt((worldPosition - fakeGrid.originPosition).y / fakeGrid.CellSize);


        if (x >= fakeGrid.width)
        {
            x = fakeGrid.width - 1;
        }
        else if (x < 0)
        {
            x = 0;
        }
        if (y >= fakeGrid.height)
        {
            y = fakeGrid.height - 1;
        }
        else if (y < 0)
        {
            y = 0;
        }
    }
    public void SaveFile()
    {
       // LevelConverter.GetInstance().CreateFile(fakeGrid.GridObjects, 10, 7);  // this means you save the files through this input which is
                                                                              // list of tiles , hardcode number width 10 , and height 7
    }

}
*/