/*
* Author: louis hoe zheng sheng
* Description: show text when the player is in the trigger and hide it when they leave
*/

using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    // Rename this to UI Panel or Backdrop so it makes more sense
    [SerializeField] private GameObject uiBackdrop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiBackdrop.SetActive(true); // Shows the backdrop AND the text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiBackdrop.SetActive(false); // Hides the backdrop AND the text
        }
    }
}