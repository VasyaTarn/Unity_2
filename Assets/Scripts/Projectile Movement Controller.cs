using UnityEngine;

public class ProjectileMovementController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Destroyable"))
        {
            Destroy(collision.gameObject);
        }

        Destroy(gameObject);
    }

    private void Update()
    {
        rb.velocity = transform.forward * speed;
    }
}
