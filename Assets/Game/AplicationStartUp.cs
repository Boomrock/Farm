using UnityEngine;
using Zenject;

public class AplicationStartUp : MonoInstaller
{
    private Camera _mainCamera; 
    private FloorView _floorView; 

    public override void InstallBindings()
    {
        var mainCamera = Container.InstantiatePrefabResourceForComponent<Camera>(ResourcesConst.MainCamera); 
        var floorView = Container.InstantiatePrefabResourceForComponent<FloorView>(ResourcesConst.Floor); 
        var menu = Container.InstantiatePrefabResourceForComponent<Canvas>(ResourcesConst.Menu);
        Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        Container.Bind<FloorView>().FromInstance(floorView).AsSingle();
        Container.Bind<Canvas>().FromInstance(menu).AsSingle();
    }
}
