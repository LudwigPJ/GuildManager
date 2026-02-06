using Assets.Scripts.Core.Config.ItemsConfig;
using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.View.ItemView;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private List<ItemsConfig> ItemByeConfigs;
    [SerializeField] private ItemView itemViewByePref;
    [SerializeField] private ShopVIew ShopVIew;
    public override void InstallBindings()
    {
        Container.Bind<ShopVIew>().FromInstance(ShopVIew).AsSingle();
        Container.Bind<ItemView>().WithId("ItemViewByePref").FromInstance(itemViewByePref).AsTransient();
        Container.BindInstance(ItemByeConfigs).WithId("ItemsByeConfigs").AsTransient();
        Container.BindInterfacesAndSelfTo<ShopController>().AsSingle().NonLazy();
        
    }
}