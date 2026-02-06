using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.ResourseView;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using static UnityEngine.Rendering.STP;

public class HeroInstaller : MonoInstaller
{
    [SerializeField] private HeroView HeroViewPref;
    [SerializeField] private List<HeroConfig> HeroConfigs;
    [SerializeField] private CasarmView CassarmView;
    [SerializeField] private CityView cityView;
    [SerializeField] private HeroView heroByeViewPref;
    [SerializeField] private List<HeroConfig> heroByeConfigs;
    public override void InstallBindings()
    {
        Container.BindInstance(HeroConfigs).WithId("CassarmConfigs").AsTransient();
        Container.Bind<HeroView>().WithId("Cassarm").FromInstance(HeroViewPref).AsTransient();
        Container.Bind<CasarmView>().FromInstance(CassarmView).AsSingle();
        Container.Bind<CityView>().FromInstance(cityView).AsSingle();
        Container.Bind<HeroView>().WithId("Bye").FromInstance(heroByeViewPref).AsTransient();
        Container.BindInstance(heroByeConfigs).WithId("ByeConfigs").AsTransient();
        Container.BindInterfacesAndSelfTo<HeroModelStorage>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ControllerHero>().AsSingle().NonLazy();
    }
}