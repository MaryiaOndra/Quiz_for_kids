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
    string targetValue;
    Vector2Int gridSize;

    List<Tile> levelTiles;
    List<string> UsedTiles = new List<string>();
    List<int> targetIndexes = new List<int>();

    private void Start()
    {
        StartGame();

        restartPanel.RestartAction = RestartGame;
    }

    void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    private void StartGame()
    {
        gridSize = gameInfo.LevelConfigs[level].GridSize;
        tileGrid.Generate(gridSize);
        tileGrid.Tiles.ForEach(_tile => _tile.TilePressedAction = CheckTileValue);
        var _levelTiles = tileGrid.Tiles;

        int _numOfConfig = UnityEngine.Random.Range(0, gameInfo.LevelConfigs.Count - 1);
        List<TileContent> _tilesContents = gameInfo.TilesContents[_numOfConfig].TilesContents;

        TilesContentFiller _tilesContentFiller = new TilesContentFiller(_tilesContents, _levelTiles);
        _tilesContentFiller.GenerateTileContent();
        targetIndexes.Add(_tilesContentFiller.SetTargetValue(targetIndexes));

        foreach (var item in targetIndexes)
        {
            Debug.Log("targetIndexes:   " + item);
        }


        targetValue = _tilesContentFiller.TargetValue;
        valueText.text = targetValue;

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
}
