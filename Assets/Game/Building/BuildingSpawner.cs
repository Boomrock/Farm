using UnityEngine;
using Zenject;

namespace Game.Building
{
    public class BuildingSpawner : MonoBehaviour
    {
        private BuildingsFactory _factory;

        [Inject]
        private void Constructor(BuildingsFactory factory)
        {
            _factory = factory;
            Spawn(BuildingType.FarmHouse);
        }

        BuildingController Spawn(BuildingType Type)
        {
            var controller = _factory.Create(Type);
            Instantiate(controller.View);
            return controller;
        }
    }
}