using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBrushPalette : MonoBehaviour
{
    public static ChangeBrushPalette instance; // Singleton
    public static ChangeBrushPalette GetInstance()
    {
        return instance;
    }
    public void Awake()
    {
        instance = this;
    }


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
