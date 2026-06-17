/*
* Author: louis hoe zheng sheng
* Description: simple script to point towards the nearest object with a specified tag, used for the point and speed pickups in the game. The arrow will only show if the pickup is within a certain distance, and will point towards the pickup even if it's off-screen.
*/

using System.Collections.Generic;
using UnityEngine;

public class TagPointer : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private List<string> targetTags = new List<string> { "Point","Speed" }; // Tags you want to track
    [SerializeField] private Transform playerTransform;   // Reference to the player
    [SerializeField] private Camera targetCamera;         // Camera used for direction calculations
    [SerializeField] private RectTransform arrowUI;       // Reference to the UI Arrow

    [Header("Settings")]
    [SerializeField] private float maxDistance = 50f;     // Only point if within this range
    [SerializeField] private bool useScreenCenter = true; // If true, point relative to camera center

    void Update()
    {
        if (playerTransform == null || arrowUI == null) return;

        Transform closestTarget = FindClosestTarget();

        if (closestTarget != null)
        {
            // Show the arrow if a target is found
            arrowUI.gameObject.SetActive(true);
            PointToTarget(closestTarget.position);
        }
        else
        {
            // Hide the arrow if no targets are nearby
            arrowUI.gameObject.SetActive(false);
        }
    }

    private Transform FindClosestTarget()
    {
        Transform closest = null;
        float closestDistance = maxDistance;

        foreach (string tag in targetTags)
        {
            if (string.IsNullOrWhiteSpace(tag)) continue;

            GameObject[] targets;
            try
            {
                targets = GameObject.FindGameObjectsWithTag(tag);
            }
            catch (UnityException)
            {
                // Ignore invalid/unconfigured tags so one bad tag doesn't break tracking.
                continue;
            }

            foreach (GameObject target in targets)
            {
                float distance = Vector3.Distance(playerTransform.position, target.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = target.transform;
                }
            }
        }

        return closest;
    }

    private void PointToTarget(Vector3 targetPosition)
    {
        Camera cam = targetCamera != null ? targetCamera : Camera.main;
        if (cam == null) return;

        Vector3 originScreenPos = useScreenCenter
            ? new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)
            : cam.WorldToScreenPoint(playerTransform.position);

        Vector3 targetScreenPos = cam.WorldToScreenPoint(targetPosition);
        Vector2 direction = (Vector2)(targetScreenPos - originScreenPos);

        // If target is behind the camera, flip direction so arrow points toward where it is off-screen.
        Vector3 toTarget = targetPosition - cam.transform.position;
        if (Vector3.Dot(cam.transform.forward, toTarget) < 0f)
        {
            direction = -direction;
        }

        if (direction.sqrMagnitude < 0.0001f) return;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        arrowUI.rotation = Quaternion.Euler(0, 0, angle);
    }
}