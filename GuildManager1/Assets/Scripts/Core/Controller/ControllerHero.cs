using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.View.ItemView;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ControllerHero
{
    private HeroView HeroViewPref;
    private HeroView HeroByeViewPref;
    private List<HeroConfig> HeroConfigs =new List<HeroConfig>(); 
    private List<HeroConfig> HeroByeConfigs = new List<HeroConfig>();
    private CasarmView _CasarmView;
    private List<HeroModel> _HeroModels = new List<HeroModel>();
    private List<HeroModel> _HeroByeModels = new List<HeroModel>();
    private List<HeroView> _HeroViews = new List<HeroView>();
    private List<HeroView> _HeroByeViews = new List<HeroView>();
    private CityView CityView;
    private HeroModel SelectHero;
    private GoldController GoldController;
    private Lazy<BlacksmithController> BlacksmithController;


    public ControllerHero(HeroView _heroViewPref, List<HeroConfig> _heroConfigs,CasarmView _casarmView, CityView _cityView, HeroView _heroByeViewPref, List<HeroConfig>_HeroByeConfigs, GoldController _GoldController, Lazy<BlacksmithController> _BlacksmithContorller )
    {
        HeroViewPref = _heroViewPref;
        HeroConfigs = _heroConfigs;
        _CasarmView = _casarmView;
        CityView = _cityView;
        HeroByeViewPref = _heroByeViewPref;
        HeroByeConfigs = _HeroByeConfigs;
        GoldController = _GoldController;
        BlacksmithController = _BlacksmithContorller;

        CityView.OnToCasarmClicked += () =>
        {
            for (int i = 0; i < _HeroModels.Count; i++)
            {
                _HeroViews[i].RefreshHero(_HeroModels[i]);
            }
        };
        foreach (HeroConfig _heroCon in HeroConfigs)
        {
            
            _HeroModels.Add(_heroCon.GetHeroModel());
            
        }

        foreach (HeroConfig _heroCon in HeroByeConfigs)
        {

            _HeroByeModels.Add(_heroCon.GetHeroModel());

        }

        RefreshHeroes();

        _casarmView.OnCasarmByeHeroes += ByeHeroes;
    }


    public void RefreshHeroes()
    {
        foreach(HeroView view in _HeroViews)
        {
            GameObject.Destroy(view.gameObject);
        }
        foreach (HeroView view in _HeroByeViews)
        {
            GameObject.Destroy(view.gameObject);
        }
        _HeroViews.Clear();
        _HeroByeViews.Clear();

        foreach (HeroModel _heroMod in _HeroModels)
        {
            _HeroViews.Add(GameObject.Instantiate(HeroViewPref, _CasarmView._heroObjectRoot.transform));
            _HeroViews.Last().RefreshHero(_heroMod);
        }
        foreach (HeroModel _heroMod in _HeroByeModels)
        {
            _HeroByeViews.Add(GameObject.Instantiate(HeroByeViewPref, _CasarmView._RootForByeHeroes.transform));
            _HeroByeViews.Last().RefreshHero(_heroMod);
        }

        foreach (HeroView view in _HeroByeViews)
        {
            view.OnHeroClick += () =>
            {
                foreach (HeroView viewbyeheroes in _HeroByeViews)
                {
                    viewbyeheroes.SelectGalochkaByeHeroes(false);
                }
                view.SelectGalochkaByeHeroes(true);
                
                _CasarmView.SelectByeHeroesButton(true);
                int index = _HeroByeViews.IndexOf(view);
                SelectHero = _HeroByeModels[index];
            };
        }

    }



    public void ByeHeroes()
    {
        if(SelectHero == null)
        {
            return;
        }
        if (GoldController.GoldMinus(SelectHero._price))
        {
            _HeroByeModels.Remove(SelectHero);
            _HeroModels.Add(SelectHero);
            RefreshHeroes();
            BlacksmithController.Value.RefreshItemSmith();
            _CasarmView.SelectByeHeroesButton(false);
            SelectHero = null;

        }
    }




    public List<HeroModel> HeroModels { get { return _HeroModels; } }



}
