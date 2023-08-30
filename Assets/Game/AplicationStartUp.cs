using UnityEngine;
using Zenject;

public class AplicationStartUp : MonoInstaller
{
    public override void InstallBindings()
    {
        var mainCamera = Container.InstantiatePrefabResourceForComponent<Camera>(ResourcesConst.MainCamera); 
        var floorView = Container.InstantiatePrefabResourceForComponent<FloorView>(ResourcesConst.Floor); 
        Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        Container.Bind<FloorView>().FromInstance(floorView).AsSingle();
        var menu = Container.InstantiatePrefabResourceForComponent<Menu>(ResourcesConst.Menu);
        Container.Bind<Menu>().FromInstance(menu).AsSingle();
    }
}
