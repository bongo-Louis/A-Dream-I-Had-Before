using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    private float currentHealth;
    private bool isAlive = true;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        if (!isAlive) return;

        currentHealth -= damageAmount;
        print($"Player took {damageAmount} damage. Health: {currentHealth}/{maxHealth}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        if (!isAlive) return;

        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        print($"Player healed {healAmount}. Health: {currentHealth}/{maxHealth}");
    }

    private void Die()
    {
        isAlive = false;
        print("Player has died! Game Over.");
        // You can add death effects here: play animation, sound, destroy gameobject, load scene, etc.
        Destroy(gameObject);
    }

    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public bool IsAlive() => isAlive;
}
