using UnityEngine;

public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;

    private GameObject heldFuel = null;

    private Vector2 lastKnownMoveInput;

    private InteractableController currentInteraction;

    private bool holdingFuel = false;

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
        if (holdingFuel)
        {
            FuelAcceptor? fuelAcceptor = other.GetComponent<FuelAcceptor>();

            if (fuelAcceptor != null)
            {
                fuelAcceptor.ReceiveFuel();
                holdingFuel = false;
                Destroy(heldFuel);
            }

            return;
        }

        InteractableController? controller = other.GetComponent<InteractableController>();

        if(controller != null && !controller.IsInUse)
        {
            currentInteraction = controller;
            currentInteraction.StartInteract();
            playerMovement.Deactivate();
        }

        if(other.gameObject.CompareTag("Fuel"))
        {
            holdingFuel = true;
            other.transform.SetParent(transform, true);
            Destroy(other.GetComponent<Rigidbody>());
            Destroy(other.GetComponent<FuelDespawn>());
            other.transform.localScale = Vector3.one;
            other.transform.localPosition = Vector3.zero;
            heldFuel = other.gameObject;
        }
    }
}
