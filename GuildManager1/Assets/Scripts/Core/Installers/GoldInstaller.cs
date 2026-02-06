using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.ResoursController;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.ResourseView;
using UnityEngine;
using Zenject;


public class GoldInstaller : MonoInstaller<GoldInstaller>
{
    [SerializeField] private GoldCountView GoldCountView;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<GoldStorage>().AsSingle().NonLazy();
        Container.Bind<GoldCountView>().FromInstance(GoldCountView).AsSingle(); 
        Container.BindInterfacesAndSelfTo<GoldController>().AsSingle().NonLazy();
    }
}