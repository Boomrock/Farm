using UnityEngine;
using Zenject;

namespace Game.Building
{
    public class BuildingsGrid : MonoBehaviour
    {
        public Vector2Int GridSize = new Vector2Int(10, 10);
        private BuldingView[,] _grid;

        private void Awake()
        {
            _grid = new BuldingView[GridSize.x, GridSize.y];
        }
        
        public bool IsPlaceTaken(int placeX, int placeY, BuildingController flyingBuilding)
        {
            for (int x = 0; x < flyingBuilding.Size.x; x++)
            {
                for (int y = 0; y < flyingBuilding.Size.y; y++)
                {
                    if (_grid[placeX + x, placeY + y] != null) return true;
                }
            }

            return false;
        }

        public void PlaceBuild(int x, int y, BuildingController buildingController)
        {
            for (int placeX = 0; placeX < buildingController.Size.x; placeX++)
            {
                for (int placeY = 0; placeY < buildingController.Size.y; placeY++)
                {
                    _grid[placeX + x , placeY + y] = buildingController.View;
                }
            }
        }
        public void UnplaceBuild(int x, int y, BuildingController buildingController)
        {
            for (int placeX = 0; placeX < buildingController.Size.x; placeX++)
            {
                for (int placeY = 0; placeY < buildingController.Size.y; placeY++)
                {
                    _grid[placeX + x , placeY + y] = null;
                }
            }
        }
        
        void OnDrawGizmos()
        {
            for (int x = 0; x < GridSize.x; x++)
            {
                for (int y = 0; y < GridSize.y ; y++)
                {
                    if ((x + y) % 2 == 0) Gizmos.color = new Color(0.88f, 0f, 1f, 0.3f);
                    else Gizmos.color = new Color(1f, 0.68f, 0f, 0.3f);

                    Gizmos.DrawCube(transform.position + new Vector3(x, 0, y), new Vector3(1, .1f, 1));
                }
            }
        }

    }
}