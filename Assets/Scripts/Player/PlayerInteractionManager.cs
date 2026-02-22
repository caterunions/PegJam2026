using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement; 

    private Vector2 lastKnownMoveInput;

    private InteractableController currentInteraction;

    public void HandleMove(Vector2 moveInput)
    {
        lastKnownMoveInput = moveInput;

        if(currentInteraction != null)
        {
            currentInteraction.HandleInput(moveInput);

            if (moveInput == currentInteraction.ExitDirection)
            {
                currentInteraction.StopInteract();
                currentInteraction = null;
                playerMovement.Activate();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        InteractableController? controller = other.GetComponent<InteractableController>();

        if(controller != null && !controller.IsInUse)
        {
            currentInteraction = controller;
            currentInteraction.StartInteract();
            playerMovement.Deactivate();
        }
    }
}
