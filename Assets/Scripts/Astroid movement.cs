using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    
    private Rigidbody rb;
    private Vector3 ScreenBounds;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    [SerializeField] private Mesh[] meshs;
    [SerializeField] private Material[] materials;

    // This is going forward in the Z x
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer.material = materials[0];
        meshFilter.mesh = meshs[Random.Range(0,meshs.Length)];
        rb = this.GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(-1, 0, 0);
        float pushX = Random.Range(-1f, 0);
        float pushY = Random.Range(-1f, 1f);
    }

    void Update()
    {
        float moveX = -4f * Time.deltaTime;
        transform.position += new Vector3(moveX, 0, 0);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }

    }
}
