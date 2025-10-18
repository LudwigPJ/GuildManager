using Assets.Scripts.Core.Controller.QuestController;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.View.QuestVIew;
using Assets.Scripts.Core.View.ResourseView;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BootsRape : MonoBehaviour
{
    private void Awake()
    {
        QuestController = new QuestController(QuestConfig);
        controller = new LocatonSwapController(CityView, TavernView, _blackSmithView,TreninngPlaceView, CasarmView, ShopVIew);
        ControllerHero = new ControllerHero(HeroViewCassarm, HeroConfigs, CasarmView);        
        goldController = new GoldController(_goldCountView);
        tavernController = new TavernController(BookView, TavernView, ControllerHero, _heroViewForBook, QuestView, QuestController, _questStartView, goldController);

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
    

    private QuestController QuestController;
    private LocatonSwapController controller;
    private TavernController tavernController;
    private ControllerHero ControllerHero;
    private GoldController goldController;


    private void OnDestroy()
    {
        controller.Dispose();
        tavernController.Dispose();
    }
}
