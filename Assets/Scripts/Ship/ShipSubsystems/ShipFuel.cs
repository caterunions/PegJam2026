using System;
using System.Collections;
using UnityEngine;

public class ShipFuel : MonoBehaviour
{
    //TODO add unity event for Zach that signals when to play processing sound
    [Header("Initialization")] [SerializeField]
    private float startingFuel = 30f;

    [SerializeField] private float maxFuel = 30f;
    [Header("Events")] [SerializeField] private float fuelLow = 0.5f;
    [SerializeField] private float fuelCritical = 0.25f;

    [Header("Processing")] [SerializeField]
    private float processingDuration = 3f;

    [Header("Dependencies")] [SerializeField]
    private ShipThrottle shipThrottle;

    public event Action OnFuelLow;
    public event Action OnFuelCritical;

    public float Fuel { get; private set; } = 30;
    public float FuelPercent => startingFuel > 0 ? Fuel / maxFuel : 0f;
    public float ProcessingProgress { get; private set; }
    private float _currentConsumptionRate = 0.5f;

    private Coroutine fuelRoutine;

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
        SceneGod.SInstance.audioSystem.PlayProcessOreSound();
        fuelRoutine = StartCoroutine(ProcessingRoutine(amount));
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

    private IEnumerator ProcessingRoutine(float amount)
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
        
        if(Fuel > 0)
        {
            Fuel += amount;
        }

        fuelRoutine = null;
    }
}