using UnityEngine;

public class FuelAcceptor : MonoBehaviour
{
    [SerializeField]
    private ShipFuel shipFuel;

    public void ReceiveFuel()
    {
        shipFuel.ProcessFuel(Random.Range(5f,6f));
    }
}
