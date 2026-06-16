using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] private Image staminaFillImage;
    private Stamina stamina;

    private void Awake()
    {
        if (staminaFillImage == null)
        {
            staminaFillImage = GetComponentInChildren<Image>(true);
        }

        if (stamina == null)
        {
            stamina = FindObjectOfType<Stamina>();
        }
    }

    private void Start()
    {
        UpdateFromStamina();
    }

    private void Update()
    {
        UpdateFromStamina();
    }

    public void UpdateStaminaBar(float currentStamina, float maxStamina)
    {
        if (staminaFillImage != null)
        {
            staminaFillImage.fillAmount = Mathf.Clamp01(currentStamina / Mathf.Max(0.0001f, maxStamina));
        }
    }

    private void UpdateFromStamina()
    {
        if (stamina == null)
        {
            stamina = FindObjectOfType<Stamina>();
            if (stamina == null)
            {
                return;
            }
        }

        UpdateStaminaBar(stamina.CurrentStamina, stamina.MaxStamina);
    }
}