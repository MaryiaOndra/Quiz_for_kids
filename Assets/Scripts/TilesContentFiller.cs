using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesContentFiller
{
    List<TileContent> tilesContents;
    List<int> tileNumbers;    
    List<int> targetNumbers = new List<int>();
    List<Tile> gridTiles;

    public int TargetNumber { get; private set; }
    public string TargetValue { get; private set; }

    public TilesContentFiller(List<TileContent> _tilesContents, List<Tile> _gridTiles) 
    {
        tilesContents = _tilesContents;
        gridTiles = _gridTiles;
    }

    internal void GenerateTileContent()
    {
        ChooseTilesAmount(gridTiles.Count);
        SetTilesContent(gridTiles);
    }

    public void SetTilesContent(List<Tile> _tiles)
    {
        for (int i = 0; i < _tiles.Count; i++)
        {
            var _content = tilesContents[tileNumbers[i]];
            _tiles[i].SetTileContent(_content);
        }
    }

    public void ChooseTilesAmount(int _tilesAmount)
    {
        tileNumbers = new List<int>();

        for (int i = 0; i < _tilesAmount; i++)
        {
            var _tileIndex = Random.Range(0, tilesContents.Count);

            if (!tileNumbers.Contains(_tileIndex))
            {
                tileNumbers.Add(_tileIndex);
            }
            else
                i--;
        }
    }

    public int SetTargetValue(List<int> _targetIndexes)
    {
        var _randomTileNmbr = Random.Range(0, tileNumbers.Count);
        var _tileIndex = tileNumbers[_randomTileNmbr];

        while (_targetIndexes.Contains(_tileIndex))
        {
            _randomTileNmbr = Random.Range(0, tileNumbers.Count);
            _tileIndex = tileNumbers[_randomTileNmbr];
        } 
        
        targetNumbers.Add(_tileIndex);  

        TargetValue = tilesContents[_tileIndex].Value;

        return _tileIndex;
    }
}
