using System;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class RestartPanel : MonoBehaviour, IFade
{
    const int ALPHA_MAX = 1;
    const int ALPHA_MIN = 0;

    [SerializeField]
    Image screenImage;

    [Header("Animation")]
    [SerializeField]
    float fadeDuration = 1.5f;

    public Action RestartAction;

    public void Activate() 
    {
        gameObject.SetActive(true);
        FadeIn();
    }

    public void Diactivate() 
    {
        RestartAction.Invoke();
    }

    public void FadeIn() 
    {
        screenImage.DOFade(ALPHA_MAX, fadeDuration);
    }

    public void FadeOut() 
    {
        screenImage.DOFade(ALPHA_MIN, fadeDuration);
    }
}
