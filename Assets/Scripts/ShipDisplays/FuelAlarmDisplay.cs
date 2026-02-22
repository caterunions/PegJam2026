using UnityEngine;

public class FuelAlarmDisplay : MonoBehaviour
{
    [SerializeField]
    private ShipFuel fuel;

    [SerializeField]
    private Animator animator;

    private void Update()
    {
        animator.SetFloat("Fuel", fuel.FuelPercent);
    }
}
