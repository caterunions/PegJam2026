using System;
using System.Collections;
using UnityEngine;

public class ShipFuel : MonoBehaviour
{
    [Header("Initialization")] [SerializeField]
    private float startingFuel = 10f;

    [SerializeField] private float maxFuel = 30f;
    [Header("Events")] [SerializeField] private float fuelLow = 0.5f;
    [SerializeField] private float fuelCritical = 0.25f;

    [Header("Processing")] [SerializeField]
    private float processingDuration = 3f;

    [Header("Dependencies")] [SerializeField]
    private ShipThrottle shipThrottle;

    public event Action OnFuelLow;
    public event Action OnFuelCritical;

    public float Fuel { get; private set; }
    public float FuelPercent => startingFuel > 0 ? Fuel / startingFuel : 0f;
    public float ProcessingProgress { get; private set; }
    private float _currentConsumptionRate;

    private void OnEnable()
    {
        if (shipThrottle != null)
            shipThrottle.OnConsumptionRateChanged += UpdateConsumptionRate;
    }

    private void OnDisable()
    {
        if (shipThrottle != null)
            shipThrottle.OnConsumptionRateChanged -= UpdateConsumptionRate;
    }

    private void UpdateConsumptionRate(float newRate)
    {
        _currentConsumptionRate = newRate;
    }

    private void Awake()
    {
        Fuel = startingFuel;
    }

    /// <summary>
    ///     Call when destroying an ore chunk
    /// </summary>
    /// <param name="amount"> Number of fuel units to add to the tank</param>
    /// <returns></returns>
    public float ProcessFuel(float amount)
    {
        StartCoroutine(ProcessFuel());
        Fuel += amount;
        return Fuel;
    }

    /// <summary>
    ///     Call on game start
    /// </summary>
    /// <param name="consumptionRate"></param>
    public void StartFuelConsumption()
    {
        StartCoroutine(ConsumeFuel());
    }

    private IEnumerator ConsumeFuel()
    {
        while (Fuel > 0f)
        {
            Fuel -= _currentConsumptionRate * Time.deltaTime;
            Fuel = Mathf.Max(Fuel, 0f);
            yield return null;
        }
    }

    private IEnumerator ProcessFuel()
    {
        float elapsed = 0f;
        ProcessingProgress = 0f;

        while (elapsed < processingDuration)
        {
            elapsed += Time.deltaTime;
            ProcessingProgress = Mathf.Clamp01(elapsed / processingDuration);
            yield return null;
        }

        ProcessingProgress = 1f;
    }
}