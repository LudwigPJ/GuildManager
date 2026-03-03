using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.ItemView;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlackSmithInstaller : MonoInstaller
{
    [SerializeField] private HeroView HeroViewForBook;
    [SerializeField] private BlackSmithView blackSmithView;
    [SerializeField] private List<ItemsConfig> itemsConfigs;
    [SerializeField] private ItemView SellitemViewPref;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<BlackSmithStorage>().AsSingle().NonLazy();
        Container.BindInstance(itemsConfigs).WithId("ItemsConfigs").AsTransient();
        Container.Bind<HeroView>().WithId("Book").FromInstance(HeroViewForBook).AsTransient();
        Container.Bind<ItemView>().WithId("SellPrefItemView").FromInstance(SellitemViewPref).AsTransient();
        Container.Bind<BlackSmithView>().FromInstance(blackSmithView).AsSingle();
        Container.BindInterfacesAndSelfTo<BlacksmithController>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ItemFabric>().AsSingle().NonLazy();
    }
}