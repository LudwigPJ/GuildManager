using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.ItemView;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ControllerHero
{
    private HeroView HeroViewPref;
    private HeroView HeroByeViewPref;
    
    private CasarmView _CasarmView;
    private HeroModelStorage heroModelStorage;
    private List<HeroView> _HeroViews = new List<HeroView>();
    private List<HeroView> _HeroByeViews = new List<HeroView>();
    private CityView CityView;
    
    private GoldController GoldController;
    private LazyInject<BlacksmithController> BlacksmithController;


    public ControllerHero(CasarmView _casarmView, CityView _cityView, GoldController _GoldController, LazyInject<BlacksmithController> _BlacksmithContorller, [Inject(Id = "Cassarm")] HeroView _HeroViewPref, [Inject(Id = "Bye")] HeroView _HeroByeViewPref, HeroModelStorage _heroModelStorage)
    {

        heroModelStorage = _heroModelStorage; 
         _CasarmView = _casarmView;
        CityView = _cityView;
        HeroViewPref = _HeroViewPref;
        HeroByeViewPref = _HeroByeViewPref;
        GoldController = _GoldController;
        BlacksmithController = _BlacksmithContorller;
        

        CityView.OnToCasarmClicked += () =>
        {
            for (int i = 0; i < heroModelStorage.HeroSystemModel.HeroModelsSystem.Count; i++)
            {
                _HeroViews[i].RefreshHero(heroModelStorage.HeroSystemModel.HeroModelsSystem[i]);
            }
        };
        

        

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

        foreach (HeroModel _heroMod in heroModelStorage.HeroSystemModel.HeroModelsSystem)
        {
            _HeroViews.Add(GameObject.Instantiate(HeroViewPref, _CasarmView._heroObjectRoot.transform));
            _HeroViews.Last().RefreshHero(_heroMod);
        }
        foreach (HeroModel _heroMod in heroModelStorage.HeroSystemModel.HeroByeModelsSystem)
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
                heroModelStorage.HeroSystemModel.SelectHeroSystem = heroModelStorage.HeroSystemModel.HeroByeModelsSystem[index];
            };
        }

    }



    public void ByeHeroes()
    {
        if (heroModelStorage.HeroSystemModel.SelectHeroSystem == null)
        {
            return;
        }
        if (GoldController.GoldMinus(heroModelStorage.HeroSystemModel.SelectHeroSystem._price))
        {
            heroModelStorage.HeroSystemModel.HeroByeModelsSystem.Remove(heroModelStorage.HeroSystemModel.SelectHeroSystem);
            heroModelStorage.HeroSystemModel.HeroModelsSystem.Add(heroModelStorage.HeroSystemModel.SelectHeroSystem);
            RefreshHeroes();
            BlacksmithController.Value.RefreshItemSmith();
            _CasarmView.SelectByeHeroesButton(false);
            heroModelStorage.HeroSystemModel.SelectHeroSystem = null;

        }
    }




    public List<HeroModel> HeroModels { get { return heroModelStorage.HeroSystemModel.HeroModelsSystem; } }



}
