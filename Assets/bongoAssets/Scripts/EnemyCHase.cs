/*
* Author: louis hoe zheng sheng
* Description: enemy ai chase logic very simple
*/

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyCHase : MonoBehaviour
{
    private NavMeshAgent agent;
    private CollectionEffect collectionEffect;
    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        collectionEffect = FindObjectOfType<CollectionEffect>();
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
    public void SpeedUp()
    {
        agent.speed += 0.025f;
        print("Enemy speed increased! Current speed: " + agent.speed);
    }
}