using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField]
    List<LevelConfig> levelConfigs;

    public List<LevelConfig> LevelConfigs => levelConfigs;
}

[Serializable]
public class LevelConfig
{
    [SerializeField]
    int level;

    [SerializeField]
    Vector2Int gridSize;

    [SerializeField]
    List<TileContent> tilesContents;

    public int Level => level;
    public Vector2Int GridSize => gridSize;
    public List<TileContent> TilesContents => tilesContents;
}

[Serializable]
public class TileContent 
{
    [SerializeField]
    char value;

    [SerializeField]
    Sprite sprite;

    public char Value => value;

}
