using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float lifetime;

    [SerializeField]
    private float speed;
    
    
    private void OnEnable()
    {
        
        rb.linearVelocity = transform.right * speed;
    }

    private void Update()
    {
        lifetime -= Time.deltaTime;

        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

}
