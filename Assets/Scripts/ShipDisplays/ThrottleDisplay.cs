using UnityEngine;

public class ThrottleDisplay : MonoBehaviour
{
    [SerializeField]
    private ShipThrottle throttle;

    [SerializeField]
    private Material goodMat;

    [SerializeField]
    private Material badMat;

    [SerializeField]
    private MeshRenderer meshRenderer;

    [SerializeField]
    private Light pointLight;

    private void Update()
    {
        if(throttle.Throttle >= 0.4f && throttle.Throttle <= 0.6f)
        {
            meshRenderer.material = goodMat;
            pointLight.color = Color.green;
        }
        else
        {
            meshRenderer.material = badMat;
            pointLight.color = Color.red;
        }
    }
}
