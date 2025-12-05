using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller.QuestController;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.View.ItemView;
using Assets.Scripts.Core.View.QuestVIew;
using Assets.Scripts.Core.View.ResourseView;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BootsRape : MonoBehaviour
{
    private void Awake()
    {
        QuestController = new QuestController(QuestConfig);
        controller = new LocatonSwapController(CityView, TavernView, _blackSmithView,TreninngPlaceView, CasarmView, ShopVIew);
        goldController = new GoldController(_goldCountView);
        ControllerHero = new ControllerHero(HeroViewCassarm, HeroConfigs, CasarmView, CityView,heroByeViewPref, HeroByeConfig, goldController, new Lazy<BlacksmithController>(() => blacksmithController));                
        tavernController = new TavernController(BookView, TavernView, ControllerHero, _heroViewForBook, QuestView, QuestController, _questStartView, goldController);
        blacksmithController = new BlacksmithController(ControllerHero, _heroViewForBook, _blackSmithView, ItemsBlacksmithConfigs, itemViewPrefSell, new Lazy<ShopController>(()=>ShopController));
        ShopController = new ShopController(ItemByeConfigs, itemViewByePref, itemViewPrefSell, blacksmithController, ShopVIew, goldController);

    }
    [SerializeField] private BlackSmithView _blackSmithView;
    [SerializeField] private CityView CityView;
    [SerializeField] private TavernView TavernView;
    [SerializeField] private BookView BookView;
    [SerializeField] private TreninngPlaceView TreninngPlaceView;
    [SerializeField] private CasarmView CasarmView;
    [SerializeField] private ShopVIew ShopVIew;
    [SerializeField] private HeroView HeroViewCassarm;
    [SerializeField] private List<HeroConfig> HeroConfigs;
    [SerializeField] private HeroView _heroViewForBook;
    [SerializeField] private QuestView QuestView;
    [SerializeField] private List<QuestConfig> QuestConfig;
    [SerializeField] private GoldCountView _goldCountView;
    [SerializeField] private QuestStartView _questStartView;
    [SerializeField] private List<ItemsConfig> ItemsBlacksmithConfigs;
    [SerializeField] private ItemView itemViewPrefSell;
    [SerializeField] private List<ItemsConfig> ItemByeConfigs;
    [SerializeField] private ItemView itemViewByePref;
    [SerializeField] private List<HeroConfig> HeroByeConfig;
    [SerializeField] private HeroView heroByeViewPref;



    private QuestController QuestController;
    private LocatonSwapController controller;
    private TavernController tavernController;
    private ControllerHero ControllerHero;
    private GoldController goldController;
    private BlacksmithController blacksmithController;
    private ShopController ShopController;


    private void OnDestroy()
    {
        controller.Dispose();
        tavernController.Dispose();
    }
}
