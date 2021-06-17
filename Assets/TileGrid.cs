using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGrid : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;
    //[SerializeField]
    //Transform rootTr;

    public List<Tile> Tiles { get; private set; }
    public Vector2Int Size { get; private set; }
    public Tile[,] TilesArray { get; private set; }

    public void Generate(Vector2Int _size)
    {
        if (Tiles != null)
        {
            Tiles.ForEach(_tile => Destroy(_tile.gameObject));
        }

        Size = _size;
        TilesArray = new Tile[_size.x, _size.y];
        Tiles = new List<Tile>((int)(_size.x * _size.y));

        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                var _tile = Instantiate(tilePrefab, transform).GetComponent<Tile>();
                _tile.SetPosition(new Vector2Int(x, y));

                TilesArray[x, y] = _tile;
                Tiles.Add(_tile);
            }
        }

        transform.position = new Vector3(-_size.x / 2f, -_size.y / 2f);
    }

    void SetContent() 
    {
    
    }
}
