using System;
using UnityEngine;

public class LocatonSwapController :IDisposable
{
    private CityView CityView;
    private TavernView TavernView;
    private BlackSmithView _BlackSmithView;
    private TreninngPlaceView _TreninngPlaceView;
    private CasarmView _CasarmView;
    private ShopVIew _ShopView;
    public LocatonSwapController (CityView cityView, TavernView tavernView,BlackSmithView blackSmithView, TreninngPlaceView treninngPlaceView, CasarmView casarmView, ShopVIew shopVIew)
    {
        CityView = cityView;
        TavernView = tavernView;
        _BlackSmithView = blackSmithView;
        _TreninngPlaceView = treninngPlaceView;
        _CasarmView = casarmView;
        _ShopView = shopVIew;
        CityView.OnReturnClicked += OnButtonOff;
        TavernView.OnOffReturnClicked += OnButtonReturn;
        _BlackSmithView.OnBlacksmithReturnClicked += OnButtonReturn;
        CityView.OnReturnBlacksmithClicked += OnButtonBlacksmith;
        CityView.OnToTreningPlaceClicked += OnButtonTreningPlace;
        _TreninngPlaceView.OnTrenningPlaceReturnToCity += OnButtonReturn;
        _CasarmView.OnCasarmReturnToCity += OnButtonReturn;
        CityView.OnToCasarmClicked += OnButtonCasarm;
        CityView.OnToShopClicked += OnButtonShop;
        _ShopView.OnReturnShopClicked += OnButtonReturn;
        OnButtonOff();


    }
    private void OnButtonShop()
    {
        _ShopView.gameObject.SetActive(true);
        CityView.gameObject.SetActive(false);
        TavernView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(false);
        _CasarmView.gameObject.SetActive(false);

    }


    private void OnButtonCasarm()
    {
        CityView.gameObject.SetActive(false);
        TavernView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(false);
        _CasarmView.gameObject.SetActive(true);
        _ShopView.gameObject.SetActive(false);
    }


    private void OnButtonTreningPlace()
    {
        CityView.gameObject.SetActive(false);
        TavernView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(true);
        _CasarmView.gameObject.SetActive(false);
        _ShopView.gameObject.SetActive(false);

    }

    private void OnButtonBlacksmith()
    {
        CityView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(true);
        TavernView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(false);
        _CasarmView.gameObject.SetActive(false);
        _ShopView.gameObject.SetActive(false);
    }
    private void OnButtonReturn()
    {
        CityView.gameObject.SetActive (true);
        TavernView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(false);
        _CasarmView.gameObject.SetActive(false);
        _ShopView.gameObject.SetActive(false);
    }

    private void OnButtonOff()
    {
        TavernView.gameObject.SetActive (true);
        CityView.gameObject.SetActive(false);
        _BlackSmithView.gameObject.SetActive(false);
        _TreninngPlaceView.gameObject.SetActive(false);
        _CasarmView.gameObject.SetActive(false);
        _ShopView.gameObject.SetActive(false);
    }

    public void Dispose()
    {
        CityView.OnReturnClicked -= OnButtonOff;
        TavernView.OnOffReturnClicked -= OnButtonReturn;
        _BlackSmithView.OnBlacksmithReturnClicked -= OnButtonReturn;
        CityView.OnReturnBlacksmithClicked -= OnButtonBlacksmith;
        CityView.OnToTreningPlaceClicked -= OnButtonTreningPlace;
        _TreninngPlaceView.OnTrenningPlaceReturnToCity -= OnButtonReturn;
        _CasarmView.OnCasarmReturnToCity -= OnButtonReturn;
        CityView.OnToCasarmClicked -= OnButtonCasarm;
        CityView.OnToShopClicked -= OnButtonShop;
        _ShopView.OnReturnShopClicked -= OnButtonReturn;
    }
}
