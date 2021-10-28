using UnityEngine;

public class BuildingsGrid : MonoBehaviour
{
    public Transform Player;
    public GameObject CellPrefab;


    private Building flyingBuilding;
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;

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

                if (Input.GetMouseButtonDown(0) && !flyingBuilding.IsConflicted)
                {
                    flyingBuilding.Renderer.material.color = Color.white;
                    flyingBuilding.IsActive = false;
                    flyingBuilding = null;
                }
            }
        }
    }

    public void StartPlacingBuilding(Building building)
    {
        if (flyingBuilding != null)
            Destroy(flyingBuilding.gameObject);

        flyingBuilding = Instantiate(building);
        flyingBuilding.IsActive = true;
    }

    private Vector2 ChooseCoordinatesWithOffset(Vector3 worldPosition)
    {
        const int minDistance = 10;
        const int maxDistance = 25;
        //TODO : написать ограничеие максимальной и минимальной дальности

        var radiusToBuilding = worldPosition - Player.position;
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
            resultVector = new Vector2(maxRadius.x, maxRadius.z) + playerPosition;
            print($"maxRadius {resultVector}");
        }
        else
        {
            resultVector = new Vector2(radiusToBuilding.x, radiusToBuilding.z) + playerPosition;
            print($"selfRadius {resultVector}");
        }

        return resultVector;
    }
}
