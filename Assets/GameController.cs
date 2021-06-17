using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameInfo gameInfo;
    [SerializeField]
    TileGrid tileGrid;

    int level = 0;
    Vector2Int gridSize;
    int tilesAmount;
    List<TileContent> levelTiles;
    char valueToFind;

    private void Start()
    {
       gridSize = gameInfo.LevelConfigs[level].GridSize;
       int _contentAmount = gameInfo.LevelConfigs[level].TilesContents.Count;

        tilesAmount = gridSize.x * gridSize.y;

        if (tilesAmount != 0)
        {
            levelTiles = new List<TileContent>();

            for (int i = 0; i < tilesAmount; i++)
            {
                int _randTile = UnityEngine.Random.Range(0, _contentAmount);
                levelTiles.Add(gameInfo.LevelConfigs[level].TilesContents[_randTile]);
            }
            Debug.Log("LEVEL TILES :" + levelTiles.Count);


            valueToFind = levelTiles[UnityEngine.Random.Range(0, levelTiles.Count)].Value;
            Debug.Log("VALUE TO FIND  :" + valueToFind);

            tileGrid.Generate(gridSize);
        }
        else
            throw new Exception("Tiles amount equals '0', change the grid size");

    }
}
