using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    [SerializeField]
    List<TilesConfigs> tilesContents;

    [SerializeField]
    List<LevelConfig> levelConfigs;

    public List<TilesConfigs> TilesContents => tilesContents;
    public List<LevelConfig> LevelConfigs => levelConfigs;
}

[Serializable]
public class LevelConfig
{
    [SerializeField]
    int levelNbr;

    [SerializeField]
    Vector2Int gridSize;

    public Vector2Int GridSize => gridSize;
    public int LevelNbr => levelNbr;
}