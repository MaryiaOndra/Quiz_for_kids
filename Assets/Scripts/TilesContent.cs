using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "My Levels Config", menuName = "Quiz/Create level Config")]
public class TilesContent : ScriptableObject
{
    [SerializeField]
    List<TileContent> tilesContents;

    public List<TileContent> TilesContents => tilesContents;    
}

[Serializable]
public class TileContent
{
    [SerializeField]
    char value;

    [SerializeField]
    Sprite tileSprite;

    public char Value => value;
    public Sprite TileSprite => tileSprite;

}
