using UnityEngine;
using UnityEngine.UI;

public class ThrottleTerminalController : InteractableController
{
    [SerializeField]
    private ShipThrottle shipThrottle;

    [SerializeField]
    private Image throttlePointer;

    private float lastKnownYInput;

    public override void HandleInput(Vector2 input)
    {
        lastKnownYInput = input.y;
    }

    private void Update()
    {
        if(lastKnownYInput != 0)
        {
            shipThrottle.UpdateThrottle(shipThrottle.Throttle + (lastKnownYInput * Time.deltaTime * -0.5f));
        }
        throttlePointer.rectTransform.localRotation = Quaternion.Euler(0, 0, (shipThrottle.Throttle - 0.5f) * 105f);
    }
}
