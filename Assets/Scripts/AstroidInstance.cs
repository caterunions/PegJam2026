using System.Collections;
using UnityEngine;

public class AstroidInstance : MonoBehaviour
{
    public GameObject astroidPrefab;
    public float respawnTime = 2.0f;
    private Vector3 screenBounds;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(AsteroidWave());
    }

    private void spawnEnemy()
    {
        GameObject astroid = Instantiate(astroidPrefab) as GameObject;
        astroid.transform.position = new Vector3(0, Random.Range(-screenBounds.y, screenBounds.y), screenBounds.z * -2);
    }

    IEnumerator AsteroidWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
    

}
