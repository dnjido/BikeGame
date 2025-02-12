using System;
using UnityEngine;
using Zenject;

public class ClickPrefabSetInstaller : MonoInstaller
{
    
    public override void InstallBindings()
    {
        Container.Bind(typeof(IMapEditorPrefabSelect), typeof(IMapEditorPrefabChange)).To<ClickPrefabSet>().AsSingle();

    }
}