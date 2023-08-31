using UnityEngine;
using Zenject;

namespace Game.Building
{
    public class Placer: ITickable
    {
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        private readonly BuildingsFactory _factory;
        private readonly BuildingsGrid _grid;
        private readonly Camera _mainCamera;        
        private Stock _stock;
        
        private BuildingController _flyingBuilding;

        public Placer(BuildingsFactory factory,BuildingsGrid grid, Camera mainCamera)
        {
            _factory = factory;
            _grid = grid;
            _mainCamera = mainCamera;
            var a = _factory.Create(BuildingType.FarmHouse);
            Debug.Log(a);
        }
        public void StartPlacingBuilding(BuildingController buildingControllerPrefab)
        {
            if (_flyingBuilding != null)
            {
                Object.Destroy(_flyingBuilding.View.gameObject);
            }

            _flyingBuilding.View = Object.Instantiate(buildingControllerPrefab.View);
        }
        private void PlaceFlyingBuilding(int x, int y)
        {
            _grid.PlaceBuild(x, y, _flyingBuilding);
            _stock.AddBuildings(_flyingBuilding);
            _flyingBuilding.SetNormal();
            _flyingBuilding = null;
        }
        public void Tick()
        {
            if (_flyingBuilding != null)
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                if (groundPlane.Raycast(ray, out float position))
                {
                    Vector3 worldPosition = ray.GetPoint(position);
                    Vector3 possitionInArray = worldPosition - _grid.transform.position;

                    int x = Mathf.RoundToInt(worldPosition.x);
                    int y = Mathf.RoundToInt(worldPosition.z);
                    int xInArray = Mathf.RoundToInt(possitionInArray.x);
                    int yInArray = Mathf.RoundToInt(possitionInArray.z);

                    bool available = true;

                    if (xInArray < 0 || xInArray > _grid.GridSize.x - _flyingBuilding.Size.x) available = false;
                    if (yInArray < 0 || yInArray > _grid.GridSize.y - _flyingBuilding.Size.y) available = false;

                    if (available &&  _grid.IsPlaceTaken(xInArray, yInArray, _flyingBuilding)) available = false;

                    _flyingBuilding.View.transform.position = new Vector3(x, 0, y);
                    _flyingBuilding.SetTransparent(available);

                    if (available && Input.GetMouseButtonDown(0))
                    {
                        PlaceFlyingBuilding(xInArray, yInArray);
                    }
                }
            }
        }
    }
}