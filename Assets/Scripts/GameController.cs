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

    int prevRandomTile;
    Vector2Int gridSize;

    List<TileContent> levelTilesContent;

    char targetValue;
    List<char> UsedTiles = new List<char>();

    private void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
       gridSize = gameInfo.LevelConfigs[level].GridSize;
       tileGrid.Generate(gridSize);

       ChooseTileContent(gameInfo.TilesContents, tileGrid.Tiles.Count);
       SetTilesContent(tileGrid.Tiles, levelTilesContent);

       SetTargetValue(tileGrid.Tiles);

        tileGrid.Tiles.ForEach(_tile => _tile.TilePressedAction = CheckTileValue);
    }

    void CheckTileValue(char _value)
    {
        if (_value == targetValue)
        {
            level++;
            StartGame();
        }
        else
            Debug.Log("WRONG");
    }

    void ChooseTileContent(List<TileContent> _tileContents, int _tilesAmount) 
    {
        int _contentAmount = gameInfo.LevelConfigs[level].TilesContents.Count;

        levelTilesContent = new List<TileContent>();

        for (int i = 0; i < _tilesAmount; i++)
        {            
            int _randomTile = UnityEngine.Random.Range(0, _contentAmount);

            levelTilesContent.Add(gameInfo.LevelConfigs[level].TilesContents[_randomTile]);
            prevRandomTile = _randomTile;
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
        UsedTiles.Add(targetValue);
    }
}
