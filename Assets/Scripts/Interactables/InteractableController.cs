using System;
using UnityEngine;

public abstract class InteractableController : MonoBehaviour
{
    [SerializeField]
    private Vector2 exitDirection = Vector2.left;
    public Vector2 ExitDirection => exitDirection;

    [SerializeField]
    private GameObject ui;

    private bool isInUse = false;
    public bool IsInUse => isInUse;

    public abstract void HandleInput(Vector2 input);

    public void StartInteract(bool player = true)
    {
        isInUse = true;

        if (ui != null && player)
        {
            ui.SetActive(true);
        }
    }

    public void StopInteract(bool player = true)
    {
        isInUse = false;

        if (ui != null && player)
        {
            ui.SetActive(false);
        }
    }
}
