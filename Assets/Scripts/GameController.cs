using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameInfo gameInfo;

    [SerializeField]
    TileGrid tileGrid;

    [SerializeField]
    TMP_Text valueText;

    [SerializeField]
    RestartPanel restartPanel;

    int level = 0;

    int prevRandomTile;
    Vector2Int gridSize;

    List<TileContent> levelTilesContent;

    string targetValue;
    List<string> UsedTiles = new List<string>();

    private void Start()
    {
        StartGame();

        restartPanel.RestartAction = RestartGame;
    }

    void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    void CheckTileValue(string _value)
    {
        if (_value == targetValue)
        {

            if (level < gameInfo.LevelConfigs.Count - 1)
            {
                level++;
                StartGame();
            }
            else
                restartPanel.Activate();
        }
    }

    void ChooseTileContent(List<TilesContentConfig> _tileContentsConfigs, int _tilesAmount) 
    {
        int _numOfConfig = UnityEngine.Random.Range(0, _tileContentsConfigs.Count);

        List<TileContent> _tileContents = _tileContentsConfigs[_numOfConfig].TilesContents;

        int _contentAmount = _tileContents.Count;

        levelTilesContent = new List<TileContent>();

        for (int i = 0; i < _tilesAmount; i++)
        {            
            int _randomTile = UnityEngine.Random.Range(0, _contentAmount);

            levelTilesContent.Add(_tileContents[_randomTile]);
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
        valueText.text = targetValue;
        UsedTiles.Add(targetValue);
    }
}
