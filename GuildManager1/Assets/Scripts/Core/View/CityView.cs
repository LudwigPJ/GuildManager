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

    public event Action OnReturnClicked;
    public event Action OnReturnBlacksmithClicked;
    public event Action OnToTreningPlaceClicked;
    public event Action OnToCasarmClicked;
    public event Action OnToShopClicked;




    private void Start()
    {
        returnCityViewButtton.onClick.AddListener(() => OnReturnClicked?.Invoke());
        returnBlacksmithButtton.onClick.AddListener(() => OnReturnBlacksmithClicked?.Invoke());
        ButtonToTreningPlace.onClick.AddListener(() => OnToTreningPlaceClicked?.Invoke());
        ButtonToCasarm.onClick.AddListener(() => OnToCasarmClicked?.Invoke());
        ButtonToShop.onClick.AddListener(() => OnToShopClicked?.Invoke());
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
