using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
   
    // This script controls the movement and behavior of an asteroid object in a Unity game. It handles the asteroid's movement, collision with lasers, and spawning of fragments upon destruction.
    public GameObject fragment;
    private Rigidbody rb;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private int minFragmentCount = 1;
    private int maxFragmentCount = 3;
    private float floatforce = 1;
    public float speed;


    [SerializeField] private Mesh[] meshs;
    [SerializeField] private Material[] materials;

    // Initializes the mesh renderer and mesh filter, sets a random mesh and material, and applies an initial velocity to the object.
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer.material = materials[0];
        meshFilter.mesh = meshs[Random.Range(0,meshs.Length)];
        rb = this.GetComponent<Rigidbody>();
        rb.linearVelocity = new Vector3(-speed * Random.Range(0.8f, 1.2f), 0, 0);
        rb.angularVelocity = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }


    // Moves the object forward in the x direction at a constant speed, and destroys it if it goes out of bounds.
    void Update()
    {
        if (rb.linearVelocity.sqrMagnitude < speed * speed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
        }

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > 60)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 30)
        {
            Destroy(gameObject);
        }

    }

    // When the object collides with an object tagged "laser", it spawns fragments and destroys itself and the laser.
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("laser"))
        {
            SpawnFragments();
            Destroy(gameObject);
            Destroy(other.transform.root.gameObject);
        }
    }


    // Spawns fragments in a circle around the destroyed object, with a random offset and random force applied to each fragment.
    void SpawnFragments()
    {
        int amountSpawned = Random.Range(minFragmentCount, maxFragmentCount + 1);
        float circle = 360f / amountSpawned;
        float randomoffset = Random.Range(0f, circle);
        float radius = 1f;

        for (int i = 0; i < amountSpawned; i++)
        {
            float angle = circle * i + randomoffset;
            float radians = angle * Mathf.Deg2Rad;
            
            Vector3 direction = new Vector3(Mathf.Cos(radians), 0, Mathf.Sin(radians));
            
            Vector3 spawnPos = transform.position + direction * radius;
            GameObject newFragment = Instantiate(fragment, new Vector3(spawnPos.x, 1.5f, spawnPos.z), Quaternion.identity);
            Rigidbody fragmentRb = newFragment.GetComponent<Rigidbody>();

            

            Vector2 random2D = Random.insideUnitCircle * 0.2f;

            direction += new Vector3(random2D.x, 0, random2D.y);

            direction.Normalize();

            

            if (fragmentRb != null)
            {
                fragmentRb.AddForce(direction * Random.Range(0.2f, 1.3f), ForceMode.Impulse);

                fragmentRb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }

        }   
    }
}
