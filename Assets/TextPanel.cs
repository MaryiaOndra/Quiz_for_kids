using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class TextPanel : MonoBehaviour
{
    const float FADE_TIME = 3f;
    const int ALPHA_MAX = 1;
    const int ZERO = 0;

    [SerializeField]
    TMP_Text titleText;    
    
    [SerializeField]
    TMP_Text valueText;

    public TMP_Text ValueText => valueText;

    void Awake()
    {
        gameObject.SetActive(false);
        titleText.DOFade(ZERO, ZERO);
        valueText.DOFade(ZERO, ZERO);
    }

    public void Appear() 
    {
        gameObject.SetActive(true);

        titleText.DOFade(ALPHA_MAX, FADE_TIME);
        valueText.DOFade(ALPHA_MAX, FADE_TIME);
    }

    public void ShowValue(string _value) 
    {
        valueText.text = _value;
    }
}
