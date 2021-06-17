using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour, IFade
{
    const int ALPHA_MAX = 1;
    const int ALPHA_MIN = 0;

    public Action LoadScreenAction;
    public Action UnLoadScreenAction;

    [SerializeField]
    Image screenImage;

    [Header("Animation")]
    [SerializeField]
    float fadeDuration = 1.5f;

    public void FadeIn()
    {
        screenImage.DOFade(ALPHA_MAX, fadeDuration).OnComplete(UnLoadScreenAction.Invoke);
    }

    public void FadeOut()
    {
        screenImage.DOFade(ALPHA_MAX, 0);
        screenImage.DOFade(ALPHA_MIN, fadeDuration).OnComplete(LoadScreenAction.Invoke); ;
    }
}
