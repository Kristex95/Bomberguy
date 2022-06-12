using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tilemap_Destruction : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile brickTile;

    public GameObject Explosion;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        DestroyTile(originCell);
        if (DestroyTile(originCell + new Vector3Int(1, 0, 0)))
        {
            DestroyTile(originCell + new Vector3Int(2, 0, 0));
        }

        if (DestroyTile(originCell + new Vector3Int(-1, 0, 0)))
        {
            DestroyTile(originCell + new Vector3Int(-2, 0, 0));
        }

        if (DestroyTile(originCell + new Vector3Int(0, 1, 0)))
        {
            DestroyTile(originCell + new Vector3Int(0, 2, 0));
        }

        if (DestroyTile(originCell + new Vector3Int(0, -1, 0)))
        {
            DestroyTile(originCell + new Vector3Int(0, -2, 0));
        }
    }

    public bool DestroyTile(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
        {
            return false;
        }

        if (tile == brickTile)
        {
            tilemap.SetTile(cell, null);
            Vector3 pos = tilemap.GetCellCenterWorld(cell);
            Instantiate(Explosion, pos, Quaternion.identity);
            return false;
        }
        else
        {
            Vector3 pos = tilemap.GetCellCenterWorld(cell);
            Instantiate(Explosion, pos, Quaternion.identity);
            return true;
        }
        
    }


}
