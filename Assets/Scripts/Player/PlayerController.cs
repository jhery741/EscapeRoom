// Caso 12: documentación del controlador de movimiento.e
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    public Transform playerCamera;

    private CharacterController controller;
    private float rotationX = 0f;
    private float verticalSpeed = 0f;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Move();
        Look();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction =
            transform.right * h + transform.forward * v;

        direction = Vector3.ClampMagnitude(direction, 1f);

        if (controller.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -2f;

        verticalSpeed += Physics.gravity.y * Time.deltaTime;

        Vector3 velocity = direction * speed;
        velocity.y = verticalSpeed;

        controller.Move(velocity * Time.deltaTime);
    }

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X")
                       * mouseSensitivity;

        float mouseY = Input.GetAxis("Mouse Y")
                       * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -80f, 80f);

        playerCamera.localRotation =
            Quaternion.Euler(rotationX, 0f, 0f);
    }
}
