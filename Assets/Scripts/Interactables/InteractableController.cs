using System;
using UnityEngine;

public abstract class InteractableController : MonoBehaviour
{
    [SerializeField]
    private Vector2 exitDirection = Vector2.left;
    public Vector2 ExitDirection => exitDirection;

    [SerializeField]
    private GameObject ui;

    public abstract void HandleInput(Vector2 input);

    public void StartInteract()
    {
        if (ui != null)
        {
            ui.SetActive(true);
        }
    }

    public void StopInteract()
    {
        if (ui != null)
        {
            ui.SetActive(false);
        }
    }
}
