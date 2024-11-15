using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private ProjectileMovementController projectilePrefab;
    private Vector3 raycastPointPosition = Vector3.zero;
    [SerializeField] private Transform projectileSpawnPoint;

    private void Update()
    {
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, Mathf.Infinity))
        {
            raycastPointPosition = raycastHit.point;
        }

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Vector3 aimDir = (raycastPointPosition - projectileSpawnPoint.position).normalized;

        Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
    }
}
