using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using static GlobalSpace.GameUtilities;


public class TileMapCreator : MonoBehaviour
{
    [SerializeField] private TileMapInfo ref_TileMapInfo;
    [SerializeField] private Tilemap ref_TileMap;

    List<TileBase> Tiles_;

    int[,] gameMap;

    private void Start()
    {
        CheckIsNotNull(ref_TileMapInfo, "ref_MapInfo in TileMapCreator");
        CheckIsNotNull(ref_TileMap, "ref_TileMap in TileMapCreator");

        Tiles_ = ref_TileMapInfo.GetTileTypes();
        ReadMap( ref_TileMapInfo.GetMapPath() );
        ShowMap();
    }

    void ReadMap(string rf_path)
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, rf_path);
        if( !File.Exists(filePath) )
        {
            Debug.Log("not exists file");
                return;
        }

        string[] allLine = File.ReadAllLines(filePath);
        int colVal = allLine.Length;
        int rowVal = allLine[0].Split(' ').Length;

        gameMap = new int[colVal, rowVal];

        for (int y = 0; y < allLine.Length; y++)
        {
            int[] l_val = allLine[y].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)         //separator: chua k.tu lam space / StringSplitOptions.RemoveEmptyEntries: ignor space 
                                    .Select(int.Parse)  //chon va chuyen thanh Int
                                    .ToArray();         //dua all du lieu allLIne[x] vao mang 1 chieu val_e

            for (int x = 0; x < l_val.Length; x++)
            {
                gameMap[y, x] = l_val[x];
            }
        }
    }

    void ShowMap()
    {
        for (var y = 0; y < gameMap.GetLength(0); y++)
        {
            for (var x = 0; x < gameMap.GetLength(1); x++)
            {

                Vector3Int tile_pos = new Vector3Int(x, -y, 0);

                TileBase tile_type = null;
                int type_val = gameMap[y, x];
                if(type_val == (int)TileMapDataType.BLANK_TILE)
                {
                    tile_type = null;
                }
                else
                {
                    tile_type = Tiles_[(int)type_val];
                }

                ref_TileMap.SetTile(tile_pos, tile_type);
            }
        }
    }
}
