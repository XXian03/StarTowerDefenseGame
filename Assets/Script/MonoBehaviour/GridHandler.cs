using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class GridHandler : MonoBehaviour
{
    public FakeGrid fakeGrid;
    [SerializeField] GameObject gObject;
    [SerializeField] TextMeshProUGUI text;

    [Header("======Tiles Related======")]
    [SerializeField] GameObject SquareBrush;
    public int BrushNumber;  // To determine what brush you using , Ground 1 , 2  or 3 etc
    [SerializeField] TileEnum tile;
    public int BrushPalette; // Used to determine what is your current Pallette you are using , Ground , Water , Fence etc

    public bool CanBrush;
  

    [Header("======Display Debug======")]
    [SerializeField] TextMeshProUGUI DebugPallete;
    [SerializeField] TextMeshProUGUI DebugBrushNumber;


    [Header("======Display Button======")]
    [SerializeField] Button ButtonDisplay_0;
    [SerializeField] Button ButtonDisplay_1;
    [SerializeField] Button ButtonDisplay_2;


    public List<Action> ListOfPallet;


    [SerializeField] GameObject ObjectHolder;
    [SerializeField] GameObject ObjectHolderSaved;
    [SerializeField] GameObject TextHolder;




    void Start()
    {


        fakeGrid = new FakeGrid(18, 10, 1, new Vector3(-9, -5));
        // create an instance of "FakeGridConstructor"  named as fakeGrid




        //At Start Create a Grid
        CreateGrid(fakeGrid);

        CanBrush = true;
   
        

    }

    void Update()
    {
        DebugPallete.text = $"Current Pallete \n{BrushPalette.ToString()}";
        DebugBrushNumber.text = $"Current Brush \n{BrushNumber.ToString()}";
        
        int x;
        int y;

        fakeGrid.GetXY(Camera.main.ScreenToWorldPoint(Input.mousePosition), out x, out y);
        SquareBrush.transform.position = fakeGrid.GridObjects[x, y].WorldPosition(fakeGrid.CellSize, fakeGrid.originPosition);

        WhatTileYouUsing(BrushNumber); // Tile That displaying on the Field now

        if (CanBrush == true)
        {
            ButtonDisplay_0.gameObject.SetActive(false);
            ButtonDisplay_1.gameObject.SetActive(false);
            ButtonDisplay_2.gameObject.SetActive(false);


            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(x + "," + y);
                //fakeGrid.GridObjects[x, y].ChangeImage(tile);
                ChangeImageByPallete(BrushPalette, fakeGrid.GridObjects[x, y], BrushNumber);  // Direct change your tile
            }
        }

        if (CanBrush == false)
        {

            ButtonDisplay_0.gameObject.SetActive(true);
            ButtonDisplay_1.gameObject.SetActive(true);
            ButtonDisplay_2.gameObject.SetActive(true);
            ChangeDisplayImage();

            if (Input.GetKeyDown(KeyCode.W))
            {
                BrushPalette -= 1;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                BrushNumber = 0;
                BrushPalette += 1;
            }

            if (BrushPalette < 0)
            {
                BrushNumber = 0;
                BrushPalette = 0;
            }


      

        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            LevelConverter.GetInstance().LoadJsonFile(gObject, ObjectHolder.transform, text , TextHolder);

           
        }


        if (Input.GetKeyDown(KeyCode.P))
        {
            if (CanBrush == true)
            {
                CanBrush = false;
            }
            else
            {
                CanBrush = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            fakeGrid.GridObjects[x, y].SetTile(tile);
        }

    }






    // Start And Create a grid function //
    private void CreateGrid(FakeGrid output)
    {
         output.GridObjects = new GridObject[output.width, output.height];

        int x;
        int y;

        for (x = 0; x < output.GridObjects.GetLength(0); x++) // Reference fakegrid's width number   
        {
            for (y = 0; y < output.GridObjects.GetLength(1); y++) // Reference fakegrid's height number 
            {
                output.GridObjects[x, y] = new GridObject(x, y); //Create Empty Object
                GameObject obj = Instantiate(gObject, output.GridObjects[x, y].WorldPosition(output.CellSize, output.originPosition), Quaternion.identity); // Generate Object
                GameObject _text = Instantiate(text.gameObject, output.GridObjects[x, y].WorldPosition(output.CellSize, output.originPosition), Quaternion.identity); // Generate Text Object 
                _text.transform.SetParent(TextHolder.transform); // Set the text under gObject 
                obj.transform.SetParent(ObjectHolder.transform); // Set gObject under TextHolder // Thinking need to seperate to GameHolder?
                output.GridObjects[x, y].Sr = obj.AddComponent<SpriteRenderer>(); // add new a SpriteRenderer into this memeber 
                //obj.GetComponent<SpriteRenderer>().sprite = placeholder;  // put a placeholder sprite for now 
                output.GridObjects[x, y].SetTile(TileEnum.Ground_1);

                _text.GetComponent<TextMeshProUGUI>().text = $"{x} , {y}";

            }
        }
    }

    // Readjust to whole number function //
    

    // File Save Function //
    public void SaveFile()
    {
        LevelConverter.GetInstance().CreateFile(fakeGrid); // this means you save the files through this input which is
                                                           // list of tiles , fakeGrid's width (18) , and height (10)
    }



    // Editor Fuction //

    public void WhatTileYouUsing(int _brushNumber)
    {
        GameAsset gA = GameAsset.GetInstance();
       switch (BrushPalette)
        {
            case 0:
                switch (_brushNumber)
                {
                    case 0
                :
                        BrushNumber = 0;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_1;
                        break;
                    case 1
                :
                        BrushNumber = 1;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_2;
                        break;
                    case 2
                :
                        BrushNumber = 2;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_3;
                        break;
                }
                break;
            case 1:
                switch (_brushNumber)
                {
                    case 0
                :
                        BrushNumber = 0;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_1;
                        break;
                    case 1
                :
                        BrushNumber = 1;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_2;
                        break;
                    case 2
                :
                        BrushNumber = 2;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_3;
                        break;
                }
                break;
            case 2:
                switch (_brushNumber)
                {
                    case 0
                :
                        BrushNumber = 0;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Fence_1;
                        break;
                    case 1
                :
                        BrushNumber = 1;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Fence_2;
                        break;
                    case 2
                :
                        BrushNumber = 2;
                        SquareBrush.GetComponent<SpriteRenderer>().sprite = gA
                            .Fence_3;
                        break;
                }
                break;
        }
        
    }

    public void ChangeImageByPallete(int _palletteNum, GridObject gridObjects, int tileNumber)
    {
        BrushPalette = _palletteNum;
        switch (BrushPalette)
        {
            case 0 // Ground
            :
                switch (tileNumber)
                {
                    case 0
                     :
                        gridObjects.SetTile(TileEnum.Ground_1);
                        break;
                    case 1
                     :
                        gridObjects.SetTile(TileEnum.Ground_2);
                        break;
                    case 2
                     :
                        gridObjects.SetTile(TileEnum.Ground_3);
                        break;
                }
                break;
            case 1 // Water
                :
                switch (tileNumber)
                {
                    case 0
               :
                        gridObjects.SetTile(TileEnum.Water_1);
                        break;
                    case 1
               :
                        gridObjects.SetTile(TileEnum.Water_2);
                        break;
                    case 2
               :
                        gridObjects.SetTile(TileEnum.Water_3);
                        break;
                }
                break;
            case 2 // Fence 
                :
                switch (tileNumber)
                {
                    case 0
       :
                        gridObjects.SetTile(TileEnum.Fence_1);
                        break;
                    case 1
       :
                        gridObjects.SetTile(TileEnum.Fence_2);
                        break;
                    case 2
       :
                        gridObjects.SetTile(TileEnum.Fence_3);
                        break;
                }
                break;
        }
    }

    public void ChangeDisplayImage()
    {
        GameAsset gA = GameAsset.GetInstance();

        switch (BrushPalette)
        {
            case 0:
                ButtonDisplay_0.GetComponent<Image>().sprite = gA.GroundSet[0];
                ButtonDisplay_1.GetComponent<Image>().sprite = gA.GroundSet[1];
                ButtonDisplay_2.GetComponent<Image>().sprite = gA.GroundSet[2];
                break;

            case 1:
                ButtonDisplay_0.GetComponent<Image>().sprite = gA.WaterSet[0];
                ButtonDisplay_1.GetComponent<Image>().sprite = gA.WaterSet[1];
                ButtonDisplay_2.GetComponent<Image>().sprite = gA.WaterSet[2];
                break;

            case 2:
                ButtonDisplay_0.GetComponent<Image>().sprite = gA.FenceSet[0];
                ButtonDisplay_1.GetComponent<Image>().sprite = gA.FenceSet[1];
                ButtonDisplay_2.GetComponent<Image>().sprite = gA.FenceSet[2];
                break;
        }

    }










    // Set Tile Type Function //

    public void SetTileTypeGround(int _brushNumber)
    {
        GameAsset gA = GameAsset.GetInstance();
        BrushNumber = _brushNumber;
        switch (BrushNumber)
        {
            case 0
                :
                BrushNumber = 0;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_1;

                break;
            case 1
                :
                BrushNumber = 1;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_2;

                break;
            case 2
                :
                BrushNumber = 2;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Ground_3;

                break;
        }
    }
    public void SetTileTypeWater(int _brushNumber)
    {
        GameAsset gA = GameAsset.GetInstance();
        BrushNumber = _brushNumber;
        switch (BrushNumber) // if brush number = 0 , the squareBrush will change to 1st tile , if 1 = 2nd tile etc so on
        {
            case 0
                :
                BrushNumber = 0;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_1;
                break;
            case 1
                :
                BrushNumber = 1;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_2;
                break;
            case 2
                :
                BrushNumber = 2;
                SquareBrush.GetComponent<SpriteRenderer>().sprite = gA.Water_3;
                break;
        }
    }



    // Change Image Based On Pallette Type//
    // Change Pallette to Ground
    public void ChangeImageGround(GridObject gridObjects, int tileNumber)
    {
        switch (tileNumber)
        {
            case 0
                :
                gridObjects.SetTile(TileEnum.Ground_1);
                break;
            case 1
                :
                gridObjects.SetTile(TileEnum.Ground_2);
                break;
            case 2
                :
                gridObjects.SetTile(TileEnum.Ground_3);
                break;
        }
    }

    // Change Pallette to Water
    public void ChangeImageWater(GridObject gridObjects, int tileNumber)
    {
        switch (tileNumber)
        {
            case 0
                :
                gridObjects.SetTile(TileEnum.Water_1);
                break;
            case 1
                :
                gridObjects.SetTile(TileEnum.Water_2);
                break;
            case 2
                :
                gridObjects.SetTile(TileEnum.Water_3);
                break;
        }
    }

    // Change Pallette to Fence
    public void ChangeImageFence(GridObject gridObjects, int tileNumber)
    {
        switch (tileNumber)
        {
            case 0
                :
                gridObjects.SetTile(TileEnum.Fence_1);
                break;
            case 1
                :
                gridObjects.SetTile(TileEnum.Fence_2);
                break;
            case 2
                :
                gridObjects.SetTile(TileEnum.Fence_3);
                break;
        }
    }




}
