/*
* Author: louis hoe zheng sheng
* Description: script to toggle the images on the ui based on how close an enemy is
*/

using UnityEngine;

public class ImageToggleController : MonoBehaviour
{
    [Header("References")]
    // Drag the object that has the ProximityDetector script here
    public proximitymeter proximityDetector; 

    [Header("UI Images")]
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;

    void Update()
    {
        if (proximityDetector == null) return;

        // Get the current proximity value (1, 2, or 3)
        int currentValue = proximityDetector.proximityValue;

        // Toggle visibility based on the value
        // Condition evaluates to true (active) or false (inactive)
        image1.SetActive(currentValue == 1);
        image2.SetActive(currentValue == 2);
        image3.SetActive(currentValue == 3);
    }
}