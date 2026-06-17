/*
* Author: louis hoe zheng sheng
* Description: simple script to handle gameover logic in the gameover scene
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void TryAgain()
    {
        if (PlayerPrefs.HasKey("LastScene"))
        {
            string sceneToLoad = PlayerPrefs.GetString("LastScene");
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("No last scene found. Loading default scene.");
            SceneManager.LoadScene("MainMenu"); // Fallback to a default scene
        }
    }
}
