using System.Collections.Generic;
using Game.Building;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using Game.Building;

public class AplicationStartUp : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<MonoBehaviour>().FromInstance(this); // context
        BindScene();
        BindBuildingFactory();
        BindShopTools();

    }
    private void BindScene()
    {
        var light = Container.InstantiatePrefabResourceForComponent<Light>(ResourcesConst.Light);
        var eventSystem = Container.InstantiatePrefabResourceForComponent<EventSystem>(ResourcesConst.EventSystem);
        
        BindMainCamera();
        BindFloor();

    }
    private void BindBuildingFactory()
    {
        Container.Bind<BuildingsFactory>().AsSingle();
        
        var config = Resources.Load<BuildingConfig>(ResourcesConst.BuildingConfig);
        config.Init();
        Container.Bind<BuildingConfig>()
            .FromInstance(config)
            .AsTransient();
        
        BindKeysToFactory(config);
    }
    private void BindShopTools()
    {
        Container.Bind<Stock>()
            .AsSingle();
        
        Container.BindInterfacesAndSelfTo<Placer>()
            .AsSingle()
            .NonLazy();
        
        Container.Bind<Shop>()
            .AsSingle();
        
        BindMenu();
       
    }

   

    private void BindMainCamera()
    {
        var mainCamera = Container.InstantiatePrefabResourceForComponent<Camera>(ResourcesConst.MainCamera);

        Container.Bind<Camera>()
            .FromInstance(mainCamera)
            .AsSingle();
    }

    private void BindFloor()
    {
        var floor = Container.InstantiatePrefabResourceForComponent<Floor>(ResourcesConst.Floor);

        Container.Bind<Floor>()
            .FromInstance(floor)
            .AsSingle();

        Container.Bind<BuildingsGrid>()
            .FromInstance(floor.Grid);
    }

    private void BindMenu()
    {
        var menu = Container.InstantiatePrefabResourceForComponent<Menu>(ResourcesConst.Menu);
        
        Container.Bind<Menu>()
            .FromInstance(menu)
            .AsSingle();
    }

   

    void BindKeysToFactory(BuildingConfig config)
    {
        config.Init();
        
        var dictionary = config.Dictionary;

        AddBinding<FarmHouseController>(BuildingType.FarmHouse);
        AddBinding<StockHouseController>(BuildingType.StockHouse);

        var farmHouseView = (FarmHouseView)dictionary[BuildingType.FarmHouse].View;
        var stockHouseView = (StockHouseView)dictionary[BuildingType.StockHouse].View;

        Container.Bind<FarmHouseView>()
            .FromInstance(farmHouseView)
            .AsSingle();
        Container.Bind<StockHouseView>()
            .FromInstance(stockHouseView)
            .AsSingle();
    }

    void AddBinding<TDerived>(BuildingType key)
        where TDerived : IWorksHouse
    {
        Container.BindInstance
                (ModestTree
                .Util
                .ValuePair
                .New(key, typeof(TDerived)))
            .WhenInjectedInto<BuildingsFactory>();
    }

}
