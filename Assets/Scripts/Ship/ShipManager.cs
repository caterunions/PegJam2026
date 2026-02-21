using UnityEngine;

public class Ship : MonoBehaviour
{
    [Header("Event Config")]
    [SerializeField] private string placeholder= "placeholdervalue";
    [Header("Refrences")] [SerializeField]
    private ShipThrottle shipThrottle;
    [SerializeField]
    private ShipFuel shipFuel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shipFuel.StartFuelConsumption();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
