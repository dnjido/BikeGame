using UnityEngine;
using Zenject;

public class SetGameStatusInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ISetGameStatus>().To<WinLoseStatus>().FromComponentInHierarchy().AsSingle();
    }
}