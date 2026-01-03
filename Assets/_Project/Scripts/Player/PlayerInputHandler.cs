using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerController controller;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        controller.SetMoveInput(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        controller.SetLookInput(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            controller.RequestJump();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        controller.SetSprint(context.ReadValueAsButton());
    }
}