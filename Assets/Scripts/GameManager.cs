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

    private void Update()
    {
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
