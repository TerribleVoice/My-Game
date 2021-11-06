using Multiplayer;
using Photon.Pun;
using UnityEngine;

namespace Buildings
{
    public class Builder : MonoBehaviour
    {
        private Transform playerTransform;
        private Camera playerCamera;
        private Building flyingBuilding;

        public void Update()
        {
            if (flyingBuilding != null)
            {
                var groundPlane = new Plane(Vector3.up, Vector3.zero);
                var ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0));

                if (groundPlane.Raycast(ray, out var position))
                {
                    var worldPosition = ray.GetPoint(position);

                    var buildingPosition = ChooseCoordinatesWithOffset(worldPosition);

                    flyingBuilding.transform.position = new Vector3(buildingPosition.x, 0, buildingPosition.y);

                    if (Input.GetMouseButtonDown(0) && !flyingBuilding.IsConflicted)
                    {
                        flyingBuilding.Place();
                        flyingBuilding = null;
                    }
                }
            }
        }

        public void StartPlacingBuilding(GameObject building)
        {
            var player = Local.Player;
            playerCamera = player.Camera;
            playerTransform = player.transform;

            if (flyingBuilding != null)
                Destroy(flyingBuilding.gameObject);

            flyingBuilding = PhotonNetwork.Instantiate(building.name, Vector3.zero, Quaternion.identity).GetComponent<Building>();
            flyingBuilding.IsActive = true;
            flyingBuilding.RenderAcceptable();
        }

        private Vector2 ChooseCoordinatesWithOffset(Vector3 worldPosition)
        {
            const int minDistance = 5;
            const int maxDistance = 25;

            var playerPosition = playerTransform.position;
            var playerPosition2D = new Vector2(playerPosition.x, playerPosition.z);
            var buildingPosition2D = new Vector2(worldPosition.x, worldPosition.z);

            var distanceToBuilding = Vector2.Distance(buildingPosition2D, playerPosition2D);
            var radiusToBuilding = buildingPosition2D - playerPosition2D;

            var minRadius = radiusToBuilding.normalized * minDistance;
            var maxRadius = radiusToBuilding.normalized * maxDistance;

            Vector2 resultVector;
            if (distanceToBuilding < minDistance)
                resultVector = playerPosition2D + minRadius;
            else if (distanceToBuilding > maxDistance)
                resultVector = playerPosition2D + maxRadius;
            else
                resultVector = radiusToBuilding + playerPosition2D;

            return resultVector;
        }
    }
}
