using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameInfo gameInfo;

    [SerializeField]
    TileGrid tileGrid;

    [SerializeField]
    TextPanel textPanel; 
    
    [SerializeField]
    LoadingPanel loadingPanel;

    [SerializeField]
    RestartPanel restartPanel;

    int level = 0;
    string targetValue;
    Vector2Int gridSize;
    List<int> targetIndexes = new List<int>();

    void Start()
    {
        gridSize = gameInfo.LevelConfigs[level].GridSize;
        tileGrid.Generate(gridSize);
        tileGrid.Tiles.ForEach(_tile => _tile.TilePressedAction = CheckTileValue);
        tileGrid.Tiles.ForEach(_tile => _tile.NextLevelAction = SceneLaunch);

        restartPanel.RestartAction = loadingPanel.FadeIn;
        loadingPanel.UnLoadScreenAction = RestartGame;
        loadingPanel.LoadScreenAction = TilesAppearing;

        SceneLaunch();

        loadingPanel.FadeOut();
    }

    void TilesAppearing() 
    {
        tileGrid.Appear();
        textPanel.Appear();
    }   

    void TilesDisappearing() 
    {
        tileGrid.Disappear();
        textPanel.Disappear();
    }   

    void RestartGame()
    {
        TilesDisappearing();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    void SceneLaunch()
    {
        if (level > gameInfo.LevelConfigs.Count - 1)
        {
            restartPanel.Activate();
        }
        else 
        {
            var _levelTiles = tileGrid.Tiles;

            int _numOfConfig = UnityEngine.Random.Range(0, gameInfo.LevelConfigs.Count - 1);
            List<TileContent> _tilesContents = gameInfo.TilesContents[_numOfConfig].TilesContents;
  
            TilesContentFiller _tilesContentFiller = new TilesContentFiller(_tilesContents, _levelTiles);
            _tilesContentFiller.GenerateTileContent();
            targetIndexes.Add(_tilesContentFiller.SetTargetValue(targetIndexes));

            targetValue = _tilesContentFiller.TargetValue;
            textPanel.ShowValue(targetValue);

        }
    }

    void CheckTileValue(Tile _tile)
    {
        if (_tile.TileValue == targetValue)
        {
            level++;
            _tile.BounceTile();
        }
        else
        {
            _tile.ShakeTile();
        }
    }
}
