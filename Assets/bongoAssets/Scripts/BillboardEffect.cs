/*
* Author: louis hoe zheng sheng
* Description: make sprite face user
*/

using UnityEngine;

public class BillboardEffect : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Start()
    {
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }
    }

    void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        Vector3 directionToPlayer = playerTransform.position - transform.position;
        directionToPlayer.y = 0f;

        if (directionToPlayer.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
