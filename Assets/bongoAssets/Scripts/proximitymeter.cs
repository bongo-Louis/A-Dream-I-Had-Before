/*
* Author: louis hoe zheng sheng
* Description: script that checks the distance between the player and enemy
*/

using UnityEngine;

public class proximitymeter : MonoBehaviour
{
    [Header("Distance Thresholds")]
    public float nearDistance = 5f;
    public float midDistance = 11f;

    [Header("Current Status")]
    public int proximityValue = 1; // 1 = Far, 2 = Mid, 3 = Near

    void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemy != null)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            UpdateProximityValue(distance);
        }
    }

    private void UpdateProximityValue(float distance)
    {
        if (distance <= nearDistance)
        {
            proximityValue = 3; // Near
            print("Enemy is Near! Proximity Value: " + proximityValue);
        }
        else if (distance <= midDistance)
        {
            proximityValue = 2; // Mid
            print("Enemy is at Mid distance. Proximity Value: " + proximityValue);
        }
        else
        {
            proximityValue = 1; // Far
            print("Enemy is Far. Proximity Value: " + proximityValue);
        }
    }
}