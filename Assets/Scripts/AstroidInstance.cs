using System.Collections;
using UnityEngine;

public class AstroidInstance : MonoBehaviour
{
    public GameObject astroidPrefab;
    public float spawnTimer;
    public float spawnInterval;

    [SerializeField] private Transform minPos;
    [SerializeField] private Transform maxPos;

    public void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            spawnObject();
        }
    }

    private void spawnObject()
    {
        Instantiate(astroidPrefab, RandomSpawnPoint(), transform.rotation);
    }

    private Vector3 RandomSpawnPoint()
    {
        Vector3 spawnpoint;

        spawnpoint.x = minPos.position.x;
        spawnpoint.y = Random.Range(minPos.position.y, maxPos.position.y);
        spawnpoint.z = Random.Range(minPos.position.z, maxPos.position.z);

        return spawnpoint;
    }
}
