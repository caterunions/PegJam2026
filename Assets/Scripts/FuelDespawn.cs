using UnityEngine;

public class FuelDespawn : MonoBehaviour
{
    private float aliveTimer = 0;
    private float curScale = 1;
    private float despawnTime = 7;

    private void Update()
    {
        aliveTimer += Time.deltaTime;

        if(aliveTimer >= despawnTime)
        {
            curScale -= Time.deltaTime / 2;
            transform.localScale = Vector3.one * curScale;

            if(curScale <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // kill when collide with ship
        if(other.gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
