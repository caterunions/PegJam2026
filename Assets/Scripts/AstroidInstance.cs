using System.Collections;
using UnityEngine;

public class AstroidInstance : MonoBehaviour
{
    public GameObject astroidPrefab;
    public float spawnTimer;
    public float spawnInterval;

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
        Instantiate(astroidPrefab, transform.position, transform.rotation);
    }
}
