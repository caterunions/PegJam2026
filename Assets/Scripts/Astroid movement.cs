using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public GameObject fragment;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private int minFragmentCount = 1;
    private int maxFragmentCount = 5;
    private float floatforce;
    public float speed;

    [SerializeField] private Mesh[] meshs;
    [SerializeField] private Material[] materials;

    // This is going forward in the x
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer.material = materials[0];
        meshFilter.mesh = meshs[Random.Range(0,meshs.Length)];
        rb = this.GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(-1, 0, 0);
        float pushX = Random.Range(-1f, 0);
        float pushZ = Random.Range(-1f, 1f);
    }

    void Update()
    {
        float moveX = speed * Time.deltaTime;
        transform.position += new Vector3(moveX, 0, 0);

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > 60)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("laser"))
        {
            SpawnFragments();
            Destroy(gameObject);
            Destroy (collision.gameObject);
        }
    }

    void SpawnFragments()
    {
        int amountSpawned = Random.Range(minFragmentCount, maxFragmentCount + 1);
        float circle = 360f / amountSpawned;
        float randomoffset = Random.Range(0f, circle);
        float radius = 2f;

        for (int i = 0; i < amountSpawned; i++)
        {
            float angle = circle * i + randomoffset;
            float radians = angle * Mathf.Deg2Rad;
            
            Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
            
            Vector3 spawnPos = transform.position + direction * radius;
            GameObject newFragment = Instantiate(fragment, spawnPos, Quaternion.identity);
            Rigidbody fragmentRb = newFragment.GetComponent<Rigidbody>();

            

            Vector2 random2D = Random.insideUnitCircle * 0.2f;

            direction += new Vector3(random2D.x, 0, random2D.y);

            direction.Normalize();

            

            if (fragmentRb != null)
            {
                fragmentRb.AddForce(direction * floatforce, ForceMode.Impulse);

                fragmentRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }

        }   
    }
}
