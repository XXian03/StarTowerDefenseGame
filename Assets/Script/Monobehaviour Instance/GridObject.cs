using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class GridObject
{
    public int x;
    public int y;
    public SpriteRenderer Sr;
    public TextMeshProUGUI Tmp;
    public TileEnum tileenum;
    public int TileType;  // Determine what tile you are, deployable or non deployable etc 
    public Entity EntityOnGrid;
   [SerializeField] public Enemy EnemyOnGrid;

    /* 0 = Can Deploy
     * 1 = Can Deploy but need to remove 
     * 2 = Water , Only Deploy if Aquatic type
     * 3 = Cannot Deploy
     * 4 = Enemy Enter
     * 5 = Enemy Exit
     */






    public GridObject (int _x , int _y)
    {
        this.x = _x;
        this.y = _y;
    }



    public bool HasEntity()  //Bool that check is there anything in the Grid 
    {
        if(EntityOnGrid == null) // If the entity on the grid got nothing 
        {
            return false; // then "return false" which also mean can Deploy something
        }
        return true; // otherwise it means there is something here, which cannot deploy
    }


    public bool HasEnemy() // Check for enemy
    {
        if(EnemyOnGrid == null) // if there is no enemy
        {
            return false; // rerturn false (which means no enemy)
        }
        return true; // else return true
    }

    public void SetEntity(Entity entity) 
    {
        EntityOnGrid = entity;  // this means whatever you set in here will be become the thing here 
    }

    public void SetEnemy(Enemy enemy)
    {
        EnemyOnGrid = enemy; // this means you can set an enemy on top of the grid because you will need to check if there is enemy or not 
    }

    public Vector3 WorldPosition(float cellsize , Vector3 originPosition)
    {
        return originPosition + new Vector3(cellsize * x + (cellsize / 2), cellsize * y + (cellsize / 2));
    }


    // Originally is Change Image // 
    public void SetTile(TileEnum _tileenum)
    {

        tileenum = _tileenum;
        GameAsset gA = GameAsset.GetInstance();


        Sprite sprite;
        switch (tileenum)
        {
            default
                :sprite = gA.Ground_1;
                TileType = 0;
                break;
            case TileEnum.Ground_1
                 :sprite = gA.Ground_1;
                TileType = 0;
                break;
            case TileEnum.Ground_2
                :sprite = gA.Ground_2;
                TileType = 0;
                break;
            case TileEnum.Ground_3
                :sprite = gA.Ground_3;
                TileType = 0;
                break;
            case TileEnum.Ground_4
                :sprite = gA.Ground_4;
                TileType = 0;
                break;
            case TileEnum.Ground_5
                :sprite = gA.Ground_5;
                TileType = 0;
                break;
            case TileEnum.Ground_6
                :sprite = gA.Ground_6;
                TileType = 0;
                break;
            case TileEnum.Ground_7
                :sprite = gA.Ground_7;
                TileType = 0;
                break;
            case TileEnum.Ground_8
                :sprite = gA.Ground_8;
                TileType = 0;
                break;
            case TileEnum.Ground_9
                :sprite = gA.Ground_9;
                TileType = 0;
                break;
            case TileEnum.Ground_10
                :sprite = gA.Ground_10;
                TileType = 0;
                break;
            case TileEnum.Water_1
                :sprite = gA.Water_1;
                TileType = 2;
                break;
            case TileEnum.Water_2
                :sprite = gA.Water_2;
                TileType = 2;
                break;
            case TileEnum.Water_3
                :sprite = gA.Water_3;
                TileType = 2;
                break;
            case TileEnum.Water_4
                :sprite = gA.Water_4;
                TileType = 2;
                break;
            case TileEnum.Water_5
                :sprite = gA.Water_5;
                TileType = 2;
                break;
            case TileEnum.Grass_1
                :sprite = gA.Grass_1;
                TileType = 3;
                break;
            case TileEnum.Grass_2
                :sprite = gA.Grass_2;
                TileType = 3;
                break;
            case TileEnum.Grass_3
                :sprite = gA.Grass_3;
                TileType = 3;
                break;
            case TileEnum.Tree_1
                : sprite = gA.Tree_1;
                TileType = 3;
                break;
            case TileEnum.Tree_2
                :sprite = gA.Tree_2;
                TileType = 3;
                break;
            case TileEnum.Tree_3
                :sprite = gA.Tree_3;
                TileType = 3;
                break;
            case TileEnum.Tree_4
                :sprite = gA.Tree_4;
                TileType = 3;
                break;
            case TileEnum.Tree_5
                :sprite = gA.Tree_5;
                TileType = 3;
                break;
            case TileEnum.Tree_6
                :sprite = gA.Tree_6;
                TileType = 3;
                break;
            case TileEnum.Fence_1
                :sprite = gA.Fence_1;
                TileType = 3;
                break;
            case TileEnum.Fence_2
                :sprite = gA.Fence_2;
                TileType = 3;
                break;
            case TileEnum.Fence_3
                :sprite = gA.Fence_3;
                TileType = 3;
                break;
            case TileEnum.Fence_4
                :sprite = gA.Fence_4;
                TileType = 3;
                break;
            case TileEnum.Fence_5
                :sprite = gA.Fence_5;
                TileType = 3;
                break;
            case TileEnum.Fence_6
                :sprite = gA.Fence_6;
                TileType = 3;
                break;
            case TileEnum.HighGround_1
                :sprite = gA.HighGround_1;
                TileType = 1;
                break;
            case TileEnum.HighGround_2
                :sprite = gA.Highground_2;
                TileType = 1;
                break;
            case TileEnum.Stump_1
                :sprite = gA.Stump_1;
                TileType = 3;
                break;
            case TileEnum.Enter_1
                :sprite = gA.Enter_1;
                TileType = 4;
                break;
            case TileEnum.Enter_2
                :sprite = gA.Enter_2;
                TileType = 4;
                break;
            case TileEnum.Exit_1
                :sprite = gA.Exit_1;
                TileType = 5;
                break;
        }

        Sr.sprite = sprite;

    }
 
}
