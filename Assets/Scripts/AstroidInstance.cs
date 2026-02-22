using System.Collections;
using UnityEngine;

public class AstroidInstance : MonoBehaviour
{
    // Public variables for the asteroid prefab, spawn timer, and spawn interval.
    [SerializeField]
    private GameObject astroidPrefab;
    [SerializeField]
    private float spawnInterval = 2;

    private float spawnTimer = 0;

    // Serialized fields for the minimum and maximum positions for spawning asteroids.
    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    // This method is called once per frame and handles the timing for spawning asteroids.
    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            Instantiate(astroidPrefab, transform.position + new Vector3(0, 0, Random.Range(-5f, 5f)), transform.rotation);
        }
    }

    // This method instantiates the asteroid prefab at a random spawn point with the same rotation as the current object.
    private void spawnObject()
    {
        
    }

    // This method generates a random spawn point within the defined min and max positions.
    private Vector3 RandomSpawnPoint()
    {
        Vector3 spawnpoint;

        spawnpoint.x = minPos.position.x;
        spawnpoint.y = minPos.position.y;
        spawnpoint.z = Random.Range(minPos.position.z, maxPos.position.z);

        return spawnpoint;
    }
}
