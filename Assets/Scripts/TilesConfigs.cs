using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Levels Config", menuName = "Quiz/Create level Config")]
public class TilesConfigs : ScriptableObject
{
    [SerializeField]
    List<TileContent> tilesContents;

    public List<TileContent> TilesContents => tilesContents;    
}

[Serializable]
public class TileContent
{
    [SerializeField]
    string value;

    [SerializeField]
    Sprite tileSprite;

    public string Value => value;
    public Sprite TileSprite => tileSprite;

}
