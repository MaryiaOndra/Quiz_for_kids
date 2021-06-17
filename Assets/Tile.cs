using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    SpriteRenderer tileSpriteRndr;
       
    public char TileValue { get; private set; }

    void Awake()
    {
        tileSpriteRndr = GetComponent<SpriteRenderer>();
    }

    public void SetTileContent(char _value, Sprite _sprite)
    {
        TileValue = _value;
        tileSpriteRndr.sprite = _sprite;
    }

    public void SetPosition(Vector2Int _position) 
    {
    
    }
}
