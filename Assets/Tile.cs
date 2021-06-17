using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    const float FIT_DELAY = 1.5f;

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
        transform.localPosition = new Vector3(_position.x * FIT_DELAY, _position.y * FIT_DELAY);
    }
}
