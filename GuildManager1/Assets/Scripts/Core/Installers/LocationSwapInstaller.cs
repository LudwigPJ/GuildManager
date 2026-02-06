using Assets.Scripts.Core.Controller.Blacksmith;
using UnityEngine;
using Zenject;

public class LocationSwapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<LocatonSwapController>().AsSingle().NonLazy();
    }
}