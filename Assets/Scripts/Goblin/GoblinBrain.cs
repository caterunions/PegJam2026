using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GoblinBrain : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    private Coroutine currentTaskRoutine;

    [SerializeField]
    private GunTerminalController gunTerminalTop;
    [SerializeField]
    private GunTerminalController gunTerminalBottom;

    private void Update()
    {
        if (currentTaskRoutine == null)
        {
            if (Random.Range(0, 4) == 0)
            {
                currentTaskRoutine = StartCoroutine(MessWithGunTask());
            }
            else
            {
                currentTaskRoutine = StartCoroutine(WanderTask());
            } 
        }
    }

    private IEnumerator WanderTask()
    {
        agent.SetDestination(transform.position + new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-10f, 10f)));

        yield return new WaitForSeconds(Random.Range(1,3));

        StopCoroutine(currentTaskRoutine);
        currentTaskRoutine = null;
    }

    private IEnumerator MessWithGunTask()
    {
        GunTerminalController selectedTerminal = Random.Range(0, 2) == 0 ? gunTerminalTop : gunTerminalBottom;

        if(selectedTerminal.IsInUse)
        {
            StopCoroutine(currentTaskRoutine);
            currentTaskRoutine = null;
        }

        agent.SetDestination(selectedTerminal.transform.position - Vector3.right);

        yield return new WaitForSeconds(0.2f);

        yield return new WaitUntil(() => agent.remainingDistance <= 0.1f);

        selectedTerminal.StartInteract(player: false);

        int times = Random.Range(2, 6);

        for(int i = 0; i < 3; i++)
        {
            selectedTerminal.HandleInput(new Vector2(0, Random.Range(0, 2) * 2 - 1));

            yield return new WaitForSeconds(Random.Range(0.3f, 1f));

            selectedTerminal.Fire();
        }

        selectedTerminal.HandleInput(Vector2.zero);

        yield return new WaitForSeconds(0.5f);

        selectedTerminal.StopInteract(player: false);

        StopCoroutine(currentTaskRoutine);
        currentTaskRoutine = null;
    }
}
