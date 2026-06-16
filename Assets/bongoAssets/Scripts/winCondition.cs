using UnityEngine;
using UnityEngine.SceneManagement;

public class winCondition : MonoBehaviour
{
    // Update is called once per frame
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Win");
        }
    }
}
