/*
* Author: louis hoe zheng sheng
* Description: ui counter logic for the blast count
*/

using UnityEngine;
using TMPro;

public class blastCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI blastText;
    [SerializeField] private blastAttack blastAttack;
    private int totalAttacks;

    private void Start()
    {
        totalAttacks = GameObject.FindGameObjectsWithTag("Attack").Length;

        if (blastAttack == null)
        {
            blastAttack = FindObjectOfType<blastAttack>();

            if (blastAttack == null)
            {
                Debug.LogWarning("blastCounter could not find a blastAttack in the scene.");
            }
        }

        UpdateAttackText();
    }

    private void Update()
    {
        UpdateAttackText();
    }

    private void UpdateAttackText()
    {
        if (blastText == null)
        {
            return;
        }

        int charges = blastAttack != null ? blastAttack.lightCharges : 0;
        blastText.text = "Attack: " + charges + " / " + totalAttacks;
    }
}
