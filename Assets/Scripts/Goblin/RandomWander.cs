using UnityEngine;
using UnityEngine.AI;

public class RandomWander : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    private void Update()
    {
        if(Random.Range(0, 500) == 1)
        {
            agent.SetDestination(transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));
        }
    }
}
