using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    private float speed = 5f;
    private Rigidbody rb;
    private Vector3 ScreenBounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       rb = this.GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(0, 0, -speed);
    }

    void Update()
    {
       
   
    }
}
