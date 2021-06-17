using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    const float FIT_DELAY = 1.5f;

    [SerializeField]
    SpriteRenderer tileSpriteRndr;
       
    public char TileValue { get; private set; }

    public void SetTileContent(TileContent _tileContent)
    {
        TileValue = _tileContent.Value;
        tileSpriteRndr.sprite = _tileContent.TileSprite;
    }

    public void SetPosition(Vector2Int _position) 
    {
        transform.localPosition = new Vector3(_position.x * FIT_DELAY, _position.y * FIT_DELAY);
    }
}
