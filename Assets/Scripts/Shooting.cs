using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private ProjectileMovementController projectilePrefab;
    private Vector3 raycastPointPosition = Vector3.zero;
    [SerializeField] private Transform projectileSpawnPoint;

    private int initialPoolSize = 10;
    private CustomPool<ProjectileMovementController> projectilePool;

    private void Start()
    {
        projectilePool = new CustomPool<ProjectileMovementController>(projectilePrefab, initialPoolSize);
    }

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
        Debug.Log(aimDir);

        var projectile = projectilePool.Get();
        projectile.transform.position = projectileSpawnPoint.position;
        projectile.transform.rotation = Quaternion.LookRotation(aimDir, Vector3.up);

        projectile.releaseProjectile(aimDir, () => projectilePool.Release(projectile));



        //Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
    }
}
