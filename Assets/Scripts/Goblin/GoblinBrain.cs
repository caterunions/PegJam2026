using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GoblinBrain : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Animator animator;

    private Coroutine currentTaskRoutine;

    [SerializeField]
    private GunTerminalController gunTerminalTop;
    [SerializeField]
    private GunTerminalController gunTerminalBottom;

    [SerializeField]
    private ThrottleTerminalController throttleTerminal;

    private void Update()
    {
        animator.SetFloat("Velocity", agent.velocity.magnitude);

        if (currentTaskRoutine == null)
        {
            if (Random.Range(0, 5) == 0)
            {
                currentTaskRoutine = StartCoroutine(MessWithGunTask());
            }
            else if (Random.Range(0, 5) == 0)
            {
                currentTaskRoutine = StartCoroutine(MessWithThrottleTask());
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

        yield return new WaitForSeconds(Random.Range(1,4));

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

        if (selectedTerminal.IsInUse)
        {
            StopCoroutine(currentTaskRoutine);
            currentTaskRoutine = null;
        }

        selectedTerminal.StartInteract(player: false);

        animator.SetBool("Interacting", true);

        int times = Random.Range(2, 6);

        for(int i = 0; i < 3; i++)
        {
            selectedTerminal.HandleInput(new Vector2(0, Random.Range(0, 2) * 2 - 1));

            yield return new WaitForSeconds(Random.Range(0.3f, 1f));

            selectedTerminal.Fire();
        }

        selectedTerminal.HandleInput(Vector2.zero);

        animator.SetBool("Interacting", false);

        yield return new WaitForSeconds(0.5f);

        selectedTerminal.StopInteract(player: false);

        StopCoroutine(currentTaskRoutine);
        currentTaskRoutine = null;
    }

    private IEnumerator MessWithThrottleTask()
    {
        if(throttleTerminal.IsInUse)
        {
            StopCoroutine(currentTaskRoutine);
            currentTaskRoutine = null;
        }

        agent.SetDestination(throttleTerminal.transform.position - Vector3.right);

        yield return new WaitForSeconds(0.2f);

        yield return new WaitUntil(() => agent.remainingDistance <= 0.1f);

        if (throttleTerminal.IsInUse)
        {
            StopCoroutine(currentTaskRoutine);
            currentTaskRoutine = null;
        }

        throttleTerminal.StartInteract(player: false);

        animator.SetBool("Interacting", true);

        throttleTerminal.HandleInput(new Vector2(0, Random.Range(0, 2) * 2 - 1));

        yield return new WaitForSeconds(Random.Range(0.3f, 1f));

        throttleTerminal.HandleInput(Vector2.zero);

        animator.SetBool("Interacting", false);

        yield return new WaitForSeconds(0.5f);

        throttleTerminal.StopInteract(player: false);

        StopCoroutine(currentTaskRoutine);
        currentTaskRoutine = null;
    }
}
