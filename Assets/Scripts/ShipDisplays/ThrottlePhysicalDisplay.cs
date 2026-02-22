using UnityEngine;

public class ThrottlePhysicalDisplay : MonoBehaviour
{
    [SerializeField]
    private ShipThrottle throttle;

    private void Update()
    {
        float rot = Mathf.Lerp(60, -25f, throttle.Throttle);
        transform.rotation = Quaternion.Euler(0, 0, rot);
    }
}
