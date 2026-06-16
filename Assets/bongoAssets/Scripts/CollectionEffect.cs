using UnityEngine;
using StarterAssets;

public class CollectionEffect : MonoBehaviour
{
    public int points = 0;
    private Health playerHealth;
    private Stamina stamina;
    private EnemyCHase enemyChase;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        stamina = GetComponent<Stamina>();
        enemyChase = FindObjectOfType<EnemyCHase>();

        if (playerHealth == null)
        {
            print("Warning: Health component not found on Player!");
        }

        if (stamina == null)
        {
            print("Warning: Stamina component not found on Player!");
        }

        if (enemyChase == null)
        {
            print("Warning: EnemyCHase component not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            points++;
            print("Points collected: " + points);
            enemyChase.SpeedUp();
            PlayPickupAudio(other.gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Hurt"))
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(playerHealth.GetMaxHealth());
            }

            PlayPickupAudio(other.gameObject);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Speed"))
        {
            if (stamina != null)
            {
                float staminaBefore = stamina.CurrentStamina;
                stamina.AddStamina(stamina.MaxStamina * 0.2f);
                print($"Stamina pickup: {staminaBefore} -> {stamina.CurrentStamina} / {stamina.MaxStamina}");
            }

            PlayPickupAudio(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    private void PlayPickupAudio(GameObject pickup)
    {
        AudioSource sound = pickup.GetComponent<AudioSource>();
        if (sound != null && sound.clip != null)
        {
            AudioSource.PlayClipAtPoint(sound.clip, pickup.transform.position);
        }
    }
}
