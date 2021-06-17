using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameInfo gameInfo;

    [SerializeField]
    TileGrid tileGrid;

    [SerializeField]
    TMP_Text valueText;

    int level = 0;
    Vector2Int gridSize;

    List<TileContent> levelTilesContent;
    char targetValue;

    private void Start()
    {
       gridSize = gameInfo.LevelConfigs[level].GridSize;
       tileGrid.Generate(gridSize);

        Debug.Log("tileGrid.Tiles.Count : " + tileGrid.Tiles.Count);

       ChooseTileContent(gameInfo.LevelConfigs[level].TilesContents, tileGrid.Tiles.Count);
       SetTilesContent(tileGrid.Tiles, levelTilesContent);

       SetTargetValue(tileGrid.Tiles);
    }

    void ChooseTileContent(List<TileContent> _tileContents, int _tilesAmount) 
    {
        int _contentAmount = gameInfo.LevelConfigs[level].TilesContents.Count;

        levelTilesContent = new List<TileContent>();

        for (int i = 0; i < _tilesAmount; i++)
        {
            int _randTile = UnityEngine.Random.Range(0, _contentAmount);
            levelTilesContent.Add(gameInfo.LevelConfigs[level].TilesContents[_randTile]);
        }
    }

    void SetTilesContent(List<Tile> _tiles, List<TileContent> _levelTiles) 
    {
        for (int i = 0; i < _tiles.Count; i++)
        {
            _tiles[i].SetTileContent(_levelTiles[i]);
        }
    }

    void SetTargetValue(List<Tile> _tiles)
    {
        targetValue = levelTilesContent[UnityEngine.Random.Range(0, levelTilesContent.Count)].Value;
        valueText.text = targetValue.ToString();
    }
}
