using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

//allows user to interact with placed tiles
// m1: place
// m2: delete
// mouse wheel: rotate
// m3: toggle
public class BuildManager : MonoBehaviour
{
    [SerializeField]
    private TileData MyTileData;

    public Tilemap tilemap;
    public List<Tile> tiles;
    public List<GameObject> UITiles;

    public int selectedTile = 0;

    //used whenever tool button is clicked
    public void SetSelection(int selection)
    {
        selectedTile = selection;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), tiles[selectedTile]);
        }else if (Input.GetMouseButton(1))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(position), null);
        }else if(Input.GetMouseButtonDown(2))
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Tile lastTile = (Tile)tilemap.GetTile(tilemap.WorldToCell(position));
            if (lastTile != null)
            {
                int lastIndex = MyTileData.GetTileIndex(lastTile);
                int newIndex = MyTileData.MiddleClick(lastIndex, position);
                tilemap.SetTile(tilemap.WorldToCell(position), tiles[newIndex]);
            }
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Tile lastTile = (Tile) tilemap.GetTile(tilemap.WorldToCell(position));
            if (lastTile != null)
            {
                int lastIndex = MyTileData.GetTileIndex(lastTile);
                int newIndex = MyTileData.RotateRightIndex(lastIndex);
                tilemap.SetTile(tilemap.WorldToCell(position), tiles[newIndex]);
            }
        }else if (Input.mouseScrollDelta.y < 0)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Tile lastTile = (Tile)tilemap.GetTile(tilemap.WorldToCell(position));
            if (lastTile != null)
            {
                int lastIndex = MyTileData.GetTileIndex(lastTile);
                int newIndex = MyTileData.RotateLeftIndex(lastIndex);
                tilemap.SetTile(tilemap.WorldToCell(position), tiles[newIndex]);
            }
        }
    }
}
