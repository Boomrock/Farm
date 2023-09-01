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
        Container.Bind<MonoBehaviour>().FromInstance(this);// context
        CreateScene();
        BuildingFactoryBinding();
        
    }

    private void CreateScene()
    {
        Container.Bind<Stock>().AsSingle();
        var mainCamera = Container.InstantiatePrefabResourceForComponent<Camera>(ResourcesConst.MainCamera);
        Container.Bind<Camera>()
            .FromInstance(mainCamera)
            .AsSingle();
        var floor = Container.InstantiatePrefabResourceForComponent<Floor>(ResourcesConst.Floor);
        Container.Bind<Floor>()
            .FromInstance(floor)
            .AsSingle();
        Container.Bind<BuildingsGrid>()
            .FromInstance(floor.Grid);
        Container.Bind<Shop>()
            .AsSingle();
        var menu = Container.InstantiatePrefabResourceForComponent<Menu>(ResourcesConst.Menu);
        Container.Bind<Menu>()
            .FromInstance(menu)
            .AsSingle();
        Container.Bind<Placer>()
            .AsSingle()
            .NonLazy();
        var light = Container.InstantiatePrefabResourceForComponent<Light>(ResourcesConst.Light);
        var eventSystem = Container.InstantiatePrefabResourceForComponent<EventSystem>(ResourcesConst.EventSystem);
    }

    private void BuildingFactoryBinding()
    {
        Container.Bind<BuildingsFactory>().AsSingle();

        var config = Resources.Load<BuildingConfig>(ResourcesConst.BuildingConfig);
        config.Init();
        InitKeysToFactory(config);
  
    }

    void InitKeysToFactory(BuildingConfig config)
    {
        config.Init();
        var dictionary = config.Dictionary;
        foreach (var buildingType in dictionary.Keys)
        {
            AddBinding<typeof((IWorksHouse)dictionary[buildingType].GetType())>(buildingType);
            Container.Bind<FarmHouseView>()
                .FromInstance()
                .AsSingle();

        }

    }
    void AddBinding<TDerived>(BuildingType key)
        where TDerived : IWorksHouse
    {
        Container.BindInstance(
            ModestTree.Util.ValuePair.New(
                key, typeof(TDerived))).WhenInjectedInto<BuildingsFactory>();
    }

}
