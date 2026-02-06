using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Model;
using UnityEngine;
using Zenject;

public class TreningPlaceInstaller : MonoInstaller
{
    [SerializeField] private TreninngPlaceView TreninngPlaceView;
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TreningPlaceStorage>().AsSingle().NonLazy();
        Container.Bind<TreninngPlaceView>().FromInstance(TreninngPlaceView).AsSingle();
        Container.BindInterfacesAndSelfTo<TreningPlaceController>().AsSingle().NonLazy();
    }
}