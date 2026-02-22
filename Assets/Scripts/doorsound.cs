using UnityEngine;

public class doorssound : MonoBehaviour
{
    //audioscript audioManager;

    private void Awake()
    {
        //audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<audioscript>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        //FIXME
        //audioManager.playsfx(audioManager.dooropening);
    }
}
