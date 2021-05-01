using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//used to return tile indexes for the tile array
//can cycle indexes between a group of tiles in an array of many groups of tiles based on SwitchType
public class TileData : MonoBehaviour
{
    public int[] rotationArray;
    public List<Tile> tiles;
    public int[] SwitchType;

    public int GetTileIndex(Tile tile)
    {
        int index = tiles.IndexOf(tile);
        return index;
    }

    //run at start/awake
    //sets the value of the tile's rotation within a group of tiles
    public void SetRotation(int index, int i)
    {
        rotationArray[index] = i;
    }

    //run at start/awake
    //used to determine the type of cycling done when rotating/toggling through a tile group
    public void SetSwitchType(int index, int i)
    {
        SwitchType[index] = i;
    }

    //pass in the index of the tile you want to rotate
    //returns index of the rotated tile
    public int RotateRightIndex(int index)
    {
        int num = SwitchType[index];
        int rotate = 1;
        switch(num)
        {
            case 1:
                return index;
            case 0:
            case 2:
                if (rotationArray[index] == 1)
                    rotate = -1;
                return index + rotate;
            case 4:
                if (rotationArray[index] == 3)
                    rotate = -3;
                return index + rotate;
        }

        return index;
    }

    public int RotateLeftIndex(int index)
    {
        int num = SwitchType[index];
        int rotate = -1;
        switch (num)
        {
            case 1:
                return index;
            case 0:
            case 2:
                if (rotationArray[index] == 0)
                    rotate = 1;
                return index + rotate;
            case 4:
                if (rotationArray[index] == 0)
                    rotate = 3;
                return index + rotate;
        }

        return index;
    }

    //used to toggle the switch
    //can later be used to modify the values of
    //  batteries, resistors, and capacitors
    public int MiddleClick(int Index, Vector3 position)
    {
        if (Index == 8 | Index == 9)
        {
            return Index +  2;
        }else if (Index == 10 | Index == 11)
        {
            return Index - 2;
        }else if(Index == 0)
        {

            return Index;
        }
        return Index;
    }

    private void Awake()
    {
        rotationArray = new int[CoolGUICreator.SpriteCount];
        SwitchType = new int[CoolGUICreator.SpriteCount];
    }

}
