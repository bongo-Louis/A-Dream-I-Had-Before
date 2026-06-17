/*
* Author: louis hoe zheng sheng
* Description: health system
*/

using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private HealthBar healthBar;
    private float currentHealth;
    private bool isAlive = true;

    private void Awake()
    {
        if (healthBar == null)
        {
            healthBar = FindObjectOfType<HealthBar>();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
    }

    public void TakeDamage(float damageAmount)
    {
        if (!isAlive) return;

        currentHealth -= damageAmount;
        print($"Player took {damageAmount} damage. Health: {currentHealth}/{maxHealth}");
        UpdateHealthUI();

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
        UpdateHealthUI();
    }

    private void Die()
    {
        isAlive = false;
        print("Player has died! Game Over.");
        string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LastScene", currentSceneName);
        PlayerPrefs.Save();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }

    public float GetCurrentHealth() => currentHealth;
    public float GetMaxHealth() => maxHealth;
    public bool IsAlive() => isAlive;

    private void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(currentHealth, maxHealth);
        }
    }
}
