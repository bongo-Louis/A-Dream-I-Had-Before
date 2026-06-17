/*
* Author: louis hoe zheng sheng
* Description: blast attack logic
*/

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class blastAttack : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Mechanics")]
    public int lightCharges = 0;
    public float blastRange = 10f;
    public float blastForce = 10f;
    [SerializeField] private float blastAimRadius = 0.6f;
    [SerializeField] private float blastCooldown = 1f;

    [Header("References")]
    public Transform playerCamera;

    private bool isBlastOnCooldown;

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && lightCharges > 0 && !isBlastOnCooldown)
        {
            PerformBlast();
            lightCharges--;
            StartCoroutine(BlastCooldown());
        }
        else if (Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame && lightCharges <= 0)
        {
            print("No light charges available!");
        }
    }

    public void addLightCharge()
    {
        lightCharges++;
        print("Light charge added! Current light charges: " + lightCharges);
    }

    void PerformBlast()
    {
        Vector3 rayOrigin = playerCamera.position;
        Vector3 rayDirection = playerCamera.forward;
        RaycastHit[] hits = Physics.SphereCastAll(rayOrigin, blastAimRadius, rayDirection, blastRange);

        foreach (RaycastHit hit in hits)
        {
            if (!IsEnemyHit(hit.collider))
            {
                continue;
            }

            Rigidbody hitRigidbody = hit.collider.attachedRigidbody;
            if (hitRigidbody != null)
            {
                Vector3 blastDirection = hit.transform.position - playerCamera.position;
                blastDirection.y = 0; // Keep the push direction horizontal
                blastDirection.Normalize();
                hitRigidbody.AddForce(blastDirection * blastForce, ForceMode.Impulse);
                print("Blast performed on: " + hit.collider.name);
                StartCoroutine(MitigateBlastEffect(hitRigidbody));
                return;
            }
        }
    }

    private bool IsEnemyHit(Collider hitCollider)
    {
        return hitCollider.CompareTag("Enemy")
            || hitCollider.transform.root.CompareTag("Enemy");
    }

    private IEnumerator MitigateBlastEffect(Rigidbody targetRigidbody)
    {
        yield return new WaitForSeconds(1f);

        if (targetRigidbody != null)
        {
            targetRigidbody.linearVelocity = Vector3.zero;
            targetRigidbody.angularVelocity = Vector3.zero;
        }
    }

    private IEnumerator BlastCooldown()
    {
        isBlastOnCooldown = true;
        yield return new WaitForSeconds(blastCooldown);
        isBlastOnCooldown = false;
    }
}