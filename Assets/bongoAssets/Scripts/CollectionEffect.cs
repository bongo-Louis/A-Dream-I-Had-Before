/*
* Author: louis hoe zheng sheng
* Description: main script that handles collection of stuff
*/

using UnityEngine;
using StarterAssets;

public class CollectionEffect : MonoBehaviour
{
    public int points = 0;
    private Health playerHealth;
    private Stamina stamina;
    private EnemyCHase enemyChase;
    private blastAttack blastAttack;

    private void Start()
    {
        playerHealth = GetComponent<Health>();
        stamina = GetComponent<Stamina>();
        blastAttack = GetComponent<blastAttack>();
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
        if (blastAttack == null)
        {
            print("Warning: blastAttack component not found on Player!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            points++;
            print("Points collected: " + points);
            if (enemyChase != null)
            {
                enemyChase.SpeedUp();
            }
            else
            {
                print("Warning: Cannot speed up enemy because EnemyCHase was not found.");
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

        else if (other.gameObject.CompareTag("Attack"))
        {
            if (blastAttack != null)
            {
                blastAttack.addLightCharge();
            }
            else
            {
                print("Warning: Cannot collect Attack pickup because blastAttack is missing.");
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
