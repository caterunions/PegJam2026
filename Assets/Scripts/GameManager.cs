using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private float requiredTime;

    private float currentTime = 0;

    [SerializeField]
    private Image filledProgressBar;

    private void Update()
    {
        currentTime += Time.deltaTime;

        filledProgressBar.fillAmount = currentTime / requiredTime;
    }
}
