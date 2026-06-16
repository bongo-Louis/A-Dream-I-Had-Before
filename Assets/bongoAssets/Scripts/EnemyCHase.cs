using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCHase : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        TryFindPlayer();
    }

    private void Update()
    {
        if (playerTransform == null)
        {
            TryFindPlayer();
            return;
        }

        if (agent.isOnNavMesh)
            agent.SetDestination(playerTransform.position);
    }

    private void TryFindPlayer()
    {
        if (playerTransform != null)
            return;

        Health playerHealth = FindObjectOfType<Health>();
        if (playerHealth != null)
        {
            playerTransform = playerHealth.transform;
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }
}