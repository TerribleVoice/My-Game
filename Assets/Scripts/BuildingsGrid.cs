using System;
using UnityEngine;
using Object = UnityEngine.Object;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    public Transform Player;
    public GameObject CellPrefab;
    public bool IsClickOnButton { get; set; }

    private Building[,] grid;
    private Building flyingBuilding;
    private Camera mainCamera;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];
        mainCamera = UnityEngine.Camera.main;
    }

    public void StartPlacingBuilding(Building building)
    {
        if (flyingBuilding != null)
        {
            Destroy(flyingBuilding.gameObject);
        }

        flyingBuilding = Instantiate(building);

        for (var x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (var y = 0; y < flyingBuilding.Size.y; y++)
            {
                var newX = -flyingBuilding.Size.x / 2 + x;
                var newY = -flyingBuilding.Size.y / 2 + y;

                var cell = Instantiate(CellPrefab, flyingBuilding.transform);
                cell.transform.localPosition = new Vector3(newX, 0, newY);
            }
        }
        IsClickOnButton = false;
    }

    public void Update()
    {
        if (flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out var position))
            {
                var worldPosition = ray.GetPoint(position);

                var buildingPosition = ChooseCoordinatesWithOffset(worldPosition);

                flyingBuilding.transform.position = new Vector3(buildingPosition.x, 0, buildingPosition.y);

                if (Input.GetMouseButtonDown(0) && !IsClickOnButton)
                {
                    HasConflictedCells();
                    // foreach (Transform child in flyingBuilding.transform)
                    // {
                    //     if (child.CompareTag("Cell"))
                    //         child.GetComponent<Renderer>().enabled = false;
                    // }
                    flyingBuilding = null;
                }
            }
        }
    }

    private bool HasConflictedCells()
    {
        foreach (Transform child in flyingBuilding.transform)
        {
            if (child.CompareTag("Cell"))
            {
                var cell = child.GetComponentInParent<Cell>();
                if (cell.IsConflicted)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private Vector2 ChooseCoordinatesWithOffset(Vector3 worldPosition)
    {
        const int minDistance = 10;
        const int maxDistance = 25;
        //TODO : написать ограничеие максимальной и минимальной дальности

        var radiusToBuilding = (worldPosition - Player.position);
        var playerPosition = new Vector2(Player.position.x, Player.position.z);
        var radiusToBuildingNormalized = radiusToBuilding.normalized;
        var minRadius = radiusToBuilding;
        minRadius.Scale(Player.forward);
        var maxRadius = radiusToBuildingNormalized * maxDistance;

        Vector2 resultVector;
        if (radiusToBuilding.magnitude < minRadius.magnitude)
        {
            resultVector = new Vector2(minRadius.x, minRadius.z) + playerPosition;
            print($"minRadius {resultVector}");
        }
        else if (radiusToBuilding.magnitude > maxRadius.magnitude)
        {
            resultVector =  new Vector2(maxRadius.x, maxRadius.z) + playerPosition;
            print($"maxRadius {resultVector}");
        }
        else
        {
            resultVector =  new Vector2(radiusToBuilding.x, radiusToBuilding.z) + playerPosition;
            print($"selfRadius {resultVector}");
        }

        return resultVector;
    }
}
