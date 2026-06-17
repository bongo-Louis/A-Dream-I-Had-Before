/*
* Author: louis hoe zheng sheng
* Description: teleporter from the tutorial
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class startCondition : MonoBehaviour
{
    // Update is called once per frame
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("ActualGameLevel3");
        }
    }
}
