using Assets.Scripts.Core.Controller;
using Assets.Scripts.Core.Controller.Blacksmith;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SaveLoadInstaller", menuName = "Installers/SaveLoadInstaller")]
public class SaveLoadInstaller : ScriptableObjectInstaller<SaveLoadInstaller>
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<SaveLoadSystemController>().AsSingle().NonLazy();
    }
}