using Assets.Scripts.Core.Controller.Blacksmith;
using Assets.Scripts.Core.Storages;
using Assets.Scripts.Core.View.QuestVIew;
using UnityEngine;
using Zenject;

public class TavernInstaller : MonoInstaller
{
    [SerializeField] private BookView BookView;
    [SerializeField] private TavernView TavernView;
    [SerializeField] private QuestView QuestView;
    [SerializeField] private QuestStartView _questStartView;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<TavernStorage>().AsSingle().NonLazy();
        Container.Bind<QuestStartView>().FromInstance(_questStartView).AsSingle();
        Container.Bind<QuestView>().FromInstance(QuestView).AsSingle();
        Container.Bind<TavernView>().FromInstance(TavernView).AsSingle();
        Container.Bind<BookView>().FromInstance(BookView).AsSingle();
        Container.BindInterfacesAndSelfTo<TavernController>().AsSingle().NonLazy();
    }
}