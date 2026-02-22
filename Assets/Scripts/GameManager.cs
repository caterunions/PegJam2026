using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float requiredTime;

    private float currentTime = 0;

    [SerializeField]
    private Image filledProgressBar;

    [SerializeField]
    private ShipThrottle throttle;

    [SerializeField]
    private ShipFuel fuel;

    [SerializeField]
    private Camera mainCam;

    [SerializeField]
    private Light skyLight;

    private float loseTimer = 4;

    private Vector3 camPos;

    private void OnEnable()
    {
        camPos = mainCam.transform.position;
    }

    private void Update()
    {
        if(fuel.Fuel <= 0)
        {
            loseTimer += Time.deltaTime;

            skyLight.intensity = 1f - (loseTimer / 4f);

            mainCam.transform.position = camPos + new Vector3(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f), 0);

            return;
        }

        if(throttle.Throttle >= 0.4f && throttle.Throttle <= 0.6f)
        {
            currentTime += Time.deltaTime;
        }
        else if(throttle.Throttle > 0.6f)
        {
            currentTime += Time.deltaTime / 3;
        }

        filledProgressBar.fillAmount = currentTime / requiredTime;
    }
}
