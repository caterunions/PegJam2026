using UnityEngine;
using UnityEngine.UI;

public class DisplayFuelPointer : MonoBehaviour
{
    [SerializeField]
    private Image pointer;

    [SerializeField]
    private ShipFuel shipFuel;

    private void Update()
    {
        pointer.rectTransform.localRotation = Quaternion.Euler(0, 0, (shipFuel.FuelPercent - 0.5f) * -105f);
    }
}
