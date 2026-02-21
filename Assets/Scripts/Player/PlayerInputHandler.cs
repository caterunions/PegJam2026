using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private PlayerMovement playerMovement;

    [SerializeField]
    private PlayerInteractionManager playerInteractionManager;

    private void OnEnable()
    {
        playerInput.actions.FindAction("Move").performed += HandleMove;
        playerInput.actions.FindAction("Move").canceled += CancelMove;
    }

    private void OnDisable()
    {
        playerInput.actions.FindAction("Move").performed -= HandleMove;
        playerInput.actions.FindAction("Move").canceled -= CancelMove;
    }

    private void HandleMove(InputAction.CallbackContext ctx)
    {
        playerMovement.HandleMove(ctx.ReadValue<Vector2>());
        playerInteractionManager.HandleMove(ctx.ReadValue<Vector2>());
    }

    private void CancelMove(InputAction.CallbackContext ctx)
    {
        playerMovement.HandleMove(Vector2.zero);
        playerInteractionManager.HandleMove(Vector2.zero);
    }
}
