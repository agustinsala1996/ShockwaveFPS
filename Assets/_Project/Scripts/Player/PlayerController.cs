using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Movimiento
    public float moveSpeed = 6f;
    public float sprintMultiplier = 1.5f;
    public float gravity = -20f;
    public float jumpForce = 8f;

    //Puntero
    public float mouseSensitivity = 2.5f;
    public float maxLookAngle = 80f;
    public Transform cameraPivot;

    CharacterController controller;
    Vector2 moveInput;
    Vector2 lookInput;
    Vector3 velocity;
    float xRotation;
    bool isSprinting;
    bool jumpRequested;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        HandleLook();
        HandleMovement();
    }

    // API Publica (Comunicacion)

    public void SetMoveInput(Vector2 value) => moveInput = value;
    public void SetLookInput(Vector2 value) => lookInput = value;
    public void SetSprint(bool value) => isSprinting = value;
    public void RequestJump() => jumpRequested = true;

    // Logica

    void HandleMovement()
    {
        float speed = isSprinting ? moveSpeed * sprintMultiplier : moveSpeed;

        if (controller.isGrounded)
        {
            if (velocity.y < 0)
                velocity.y = -2f;

            if (jumpRequested)
            {
                velocity.y = jumpForce;
                jumpRequested = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 move =
            (transform.right * moveInput.x +
             transform.forward * moveInput.y) * speed;

        Vector3 finalMove = move + Vector3.up * velocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }

    void HandleLook()
    {
        float mouseX = lookInput.x * mouseSensitivity;
        float mouseY = lookInput.y * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -maxLookAngle, maxLookAngle);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}