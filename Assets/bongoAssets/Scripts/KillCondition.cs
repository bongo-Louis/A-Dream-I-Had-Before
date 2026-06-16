using UnityEngine;

public class KillCondition : MonoBehaviour
{
    [SerializeField] private float damageCooldown = 1f; // Time to wait between attacks
    private float nextDamageTime = 0f; // Tracks when the player can be hurt again

    // Changed to OnTriggerStay so it keeps checking while the enemy is touching the player
    private void OnTriggerStay(Collider other)
    {
        // Check if enough time has passed since the last damage
        if (Time.time >= nextDamageTime)
        {
            Health playerHealth = other.GetComponentInParent<Health>();
            if (playerHealth != null)
            {
                print("Player has been caught by the enemy! Taking 50 damage.");
                playerHealth.TakeDamage(50f);

                // Set the next time the player can take damage (Current Time + 1 Second)
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}