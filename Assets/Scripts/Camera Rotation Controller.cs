using UnityEngine;

public class CameraRotationController : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        cameraRotation();
    }

    private void cameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
