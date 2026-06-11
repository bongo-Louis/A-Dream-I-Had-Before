using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        // Finds the player by their tag. Make sure your Player object is tagged as "Player"!
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    void Update()
    {
        // If the player exists, update the destination every frame
        if (playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}