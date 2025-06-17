using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileMapInfo : MonoBehaviour
{
    [SerializeField] string map_path_;
    public string GetMapPath() => map_path_;

    [SerializeField] List<TileBase> tile_types_;
    public List<TileBase> GetTileTypes() => tile_types_;
}
