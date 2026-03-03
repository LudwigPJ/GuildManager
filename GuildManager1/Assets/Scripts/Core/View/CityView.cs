using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CityView : MonoBehaviour
{
    [SerializeField] private Button returnCityViewButtton;
    [SerializeField] private Button returnBlacksmithButtton;
    [SerializeField] private Button ButtonToTreningPlace;
    [SerializeField] private Button ButtonToCasarm;
    [SerializeField] private Button ButtonToShop;
    [SerializeField] private CanvasGroup CityViewCanvasGroup;

    public event Action OnReturnClicked;
    public event Action OnReturnBlacksmithClicked;
    public event Action OnToTreningPlaceClicked;
    public event Action OnToCasarmClicked;
    public event Action OnToShopClicked;
    private Sequence HideTween;
    private Tween ShowTween;






    private void Start()
    {
        returnCityViewButtton.onClick.AddListener(() => OnReturnClicked?.Invoke());
        returnBlacksmithButtton.onClick.AddListener(() => OnReturnBlacksmithClicked?.Invoke());
        ButtonToTreningPlace.onClick.AddListener(() => OnToTreningPlaceClicked?.Invoke());
        ButtonToCasarm.onClick.AddListener(() => OnToCasarmClicked?.Invoke());
        ButtonToShop.onClick.AddListener(() => OnToShopClicked?.Invoke());
    }

    public void Show()
    {
        ShowTween.Kill();
        HideTween.Kill();
        CityViewCanvasGroup.alpha = 0;
        gameObject.SetActive(true);
        ShowTween = CityViewCanvasGroup.DOFade(1, 2);
    }

    public void Hide()
    {
        ShowTween.Kill();
        HideTween.Kill();
        HideTween = DOTween.Sequence();
        HideTween.Append(CityViewCanvasGroup.DOFade(0, 2));
        HideTween.AppendCallback(() =>
        {
            gameObject.SetActive(false);
            CityViewCanvasGroup.alpha = 0;
        });
        
        

    }



    private void OnDestroy()
    {
        returnCityViewButtton.onClick.RemoveAllListeners();
        returnBlacksmithButtton.onClick.RemoveAllListeners();
        ButtonToTreningPlace.onClick.RemoveAllListeners();
        ButtonToCasarm.onClick.RemoveAllListeners();
        ButtonToShop.onClick.RemoveAllListeners();
    }



}
