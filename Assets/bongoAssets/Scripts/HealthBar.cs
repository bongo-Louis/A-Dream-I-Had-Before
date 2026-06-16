using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthFillImage;

    private void Awake()
    {
        if (healthFillImage == null)
        {
            healthFillImage = GetComponentInChildren<Image>(true);
        }
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthFillImage != null)
        {
            healthFillImage.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
            print($"Health Bar Updated: {currentHealth}/{maxHealth} ({healthFillImage.fillAmount * 100}%)");
        }
    }
}