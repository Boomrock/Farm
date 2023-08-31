using Game.Building;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Game.Building;

public class AplicationStartUp : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MonoBehaviour>().FromInstance(this);// context

        Container.Bind<Stock>().AsSingle();
        Container.Bind<BuildingsFactory>().AsSingle();
        AddBinding<FarmHouseController>(BuildingType.FarmHouse);
        
        
        
        var mainCamera = Container.InstantiatePrefabResourceForComponent<Camera>(ResourcesConst.MainCamera); 
        Container.Bind<Camera>().FromInstance(mainCamera).AsSingle();
        
        var floor = Container.InstantiatePrefabResourceForComponent<Floor>(ResourcesConst.Floor);
        Container.Bind<Floor>().FromInstance(floor).AsSingle();

        Container.Bind<BuildingsGrid>().FromInstance(floor.Grid);

        Container.Bind<Shop>().AsSingle();
        
        var light = Container.InstantiatePrefabResourceForComponent<Light>(ResourcesConst.Light);
        var eventSystem = Container.InstantiatePrefabResourceForComponent<EventSystem>(ResourcesConst.EventSystem);
        var menu = Container.InstantiatePrefabResourceForComponent<Menu>(ResourcesConst.Menu);
        Container.Bind<Menu>().FromInstance(menu).AsSingle();
        Container.Bind<Placer>().AsSingle().NonLazy();




    }
    
    void AddBinding<TDerived>(BuildingType key)
        where TDerived : IWorksHouse
    {
        Container.BindInstance(
            ModestTree.Util.ValuePair.New(
                key, typeof(TDerived))).WhenInjectedInto<BuildingsFactory>();
    }

}
