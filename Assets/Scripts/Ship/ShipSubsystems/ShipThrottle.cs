using System;
using UnityEngine;

public class ShipThrottle : MonoBehaviour
{
    [SerializeField] private float shipMaxFuelConsumption = 1f;
    [Range(0.0f, 1.0f)] public float Throttle { get; private set; }

    public event Action<float> OnConsumptionRateChanged;

    public void Update()
    {
        //TODO later Scale particle effects on engines by curr throttle
    }

    public void UpdateThrottle(float value)
    {
        Throttle = Mathf.Clamp01(value);
        float newConsumptionRate = shipMaxFuelConsumption * Throttle;
        OnConsumptionRateChanged?.Invoke(newConsumptionRate);
    }
}