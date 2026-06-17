/*
* Author: louis hoe zheng sheng
* Description: simple script to lock cursor again when in game again
*/

using UnityEngine;

public class Player3DInit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}