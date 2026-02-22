using UnityEngine;

public class DisplayUIOnPlayerTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    private void OnTriggerEnter(Collider other)
    {
        ui.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ui.SetActive(false);
    }
}
