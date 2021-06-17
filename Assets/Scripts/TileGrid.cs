using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;
    [SerializeField]
    Transform rootTr;

    public List<Tile> Tiles { get; private set; }
    public Vector2Int Size { get; private set; }

    float rootFitterY = 0.5f;
    float rootFitterX = 0.5f;

    public void Generate(Vector2Int _size)
    {
        if (Tiles != null)
        {
            Tiles.ForEach(_tile => Destroy(_tile.gameObject));
        }

        Size = _size;
        Tiles = new List<Tile>((int)(_size.x * _size.y));

        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                var _tile = Instantiate(tilePrefab, rootTr).GetComponent<Tile>();
                _tile.SetPosition(new Vector2Int(x, y));

                Tiles.Add(_tile);
            }
        }

        if (_size.y == 1)
            rootFitterY = 0;
        else
            rootFitterY = rootFitterX;

            rootTr.localPosition = new Vector3(-_size.x * rootFitterX, -_size.y * rootFitterY);
    }

    void SetContent() 
    {
    
    }
}
