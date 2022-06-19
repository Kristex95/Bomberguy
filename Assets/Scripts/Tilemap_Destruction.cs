using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tilemap_Destruction : MonoBehaviour
{
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile brickTile;

    [Range(0, 100)]
    public int powerupChance;
    public GameObject powerup;
    public GameObject Explosion;

    public void Explode(Vector2 worldPos, int radius)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        DestroyTile(originCell);

        for (int i = 1; i <= radius; i++)
        {
            if(!DestroyTile(originCell + new Vector3Int(i, 0, 0)))
            {
                break;
            }
        }

        for (int i = 1; i <= radius; i++)
        {
            if (!DestroyTile(originCell + new Vector3Int(-i, 0, 0)))
            {
                break;
            }
        }

        for (int i = 1; i <= radius; i++)
        {
            if (!DestroyTile(originCell + new Vector3Int(0, i, 0)))
            {
                break;
            }
        }

        for (int i = 1; i <= radius; i++)
        {
            if (!DestroyTile(originCell + new Vector3Int(0, -i, 0)))
            {
                break;
            }
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

            int rand = (int)Random.Range(0f, 100f);
            if (rand <= powerupChance)
            {
                GameObject pUp = Instantiate(powerup);
                pUp.transform.position = pos;
            }

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
