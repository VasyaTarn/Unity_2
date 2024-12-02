using System;
using UnityEngine;

public class ProjectileMovementController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed;

    private Action onReleaseCallback;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Point"))
        {
            collision.gameObject.SetActive(false);
            GameManger.Instance.addScore(1);
        }

        onReleaseCallback?.Invoke();
    }

    public void releaseProjectile(Vector3 direction, Action releaseCallback)
    {
        if(rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        onReleaseCallback = releaseCallback;

        rb.velocity = direction * speed;
    }
}
