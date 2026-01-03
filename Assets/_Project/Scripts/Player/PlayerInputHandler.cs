using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerController controller;
    WeaponBase currentWeapon;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        currentWeapon = GetComponentInChildren<WeaponBase>();
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

    public void OnFirePrimary(InputAction.CallbackContext context)
    {
        if (context.performed && currentWeapon != null)
        {
            currentWeapon.Fire();
        }
    }
}