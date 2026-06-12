using UnityEngine;

public class KillCondition : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Player has been caught by the enemy! Game Over.");
        }
    }
}
