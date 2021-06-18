using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tile : MonoBehaviour
{
    const float FIT_DELAY = 1.5f;

    [SerializeField]
    SpriteRenderer tileSpriteRndr;
    [SerializeField]
    GameObject starParticle;

    [Header("Animation")]
    [SerializeField]
    float shakeDuration =1f;   
    [SerializeField]
    float bounceDuration = 0.5f;   
    [SerializeField]
    float duration = 0.5f;
    [SerializeField]
    Ease bounceEase;

    public Action< Tile> TilePressedAction;
    public Action NextLevelAction;

    public string TileValue { get; private set; }

    public void SetTileContent(TileContent _tileContent)
    {
        TileValue = _tileContent.Value;
        tileSpriteRndr.sprite = _tileContent.TileSprite;
    }

    public void SetPosition(Vector2Int _position) 
    {
        transform.localPosition = new Vector3(_position.x * FIT_DELAY, _position.y * FIT_DELAY);
    }

    public void OnPressed() 
    {
        TilePressedAction.Invoke(this);
    }

    public void ShakeTile() 
    {
        tileSpriteRndr.gameObject.transform
            .DOShakeRotation(shakeDuration, 60, 5, 90);
    }

    public void BounceTile() 
    {
        starParticle.SetActive(true);

        tileSpriteRndr.gameObject.transform
            .DOScale(Vector3.one * 1.3f, bounceDuration)
            .SetEase(bounceEase)
            .SetLoops(3, LoopType.Yoyo)
            .OnComplete(CompleteEffects);
    }

    void CompleteEffects() 
    {
        starParticle.SetActive(false);
        tileSpriteRndr.gameObject.transform.DOScale(Vector3.one, bounceDuration).OnComplete(NextLevelAction.Invoke);
    }
}
