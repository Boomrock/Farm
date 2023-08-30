using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    [SerializeField]
    private Stock stock;



    public Vector2Int GridSize = new Vector2Int(10, 10);
    private Building[,] grid;
    private Building flyingBuilding;
    private Camera mainCamera;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];

        mainCamera = Camera.main;
    }

    public void StartPlacingBuilding(Building buildingPrefab)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(buildingPrefab);
    }
    Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    private void Update()
    {
        if (flyingBuilding != null)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);
                Vector3 possitionInArray = worldPosition - transform.position;

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);
                int xInArray = Mathf.RoundToInt(possitionInArray.x);
                int yInArray = Mathf.RoundToInt(possitionInArray.z);

                bool available = true;

                if (xInArray < 0 || xInArray > GridSize.x - flyingBuilding.Size.x) available = false;
                if (yInArray < 0 || yInArray > GridSize.y - flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(xInArray, yInArray )) available = false;

                flyingBuilding.transform.position = new Vector3(x, 0, y);
                flyingBuilding.SetTransparent(available);

                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(xInArray, yInArray);
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
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
    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x , placeY + y] = flyingBuilding;
            }
        }
        stock.AddBuildings(flyingBuilding.GetComponent<IWorksHouse>());
        flyingBuilding.SetNormal();
        flyingBuilding = null;


    }
}