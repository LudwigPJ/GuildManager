using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Storages;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class QuestsInstaller : MonoInstaller<QuestsInstaller>
{
    [SerializeField] private List<QuestConfig> Configs;
    public override void InstallBindings()
    {
        Container.BindInstance(Configs).AsSingle();
        Container.BindInterfacesAndSelfTo<QuestStorage>().AsSingle().NonLazy();
    }
}