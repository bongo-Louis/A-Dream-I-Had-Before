using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private CollectionEffect collectionEffect;
	private int totalPoints;

	private void Start()
	{
		totalPoints = GameObject.FindGameObjectsWithTag("Point").Length;

		if (collectionEffect == null)
		{
			collectionEffect = FindObjectOfType<CollectionEffect>();

			if (collectionEffect == null)
			{
				Debug.LogWarning("ScoreCounter could not find a CollectionEffect in the scene.");
			}
			}

		UpdateScoreText();
	}

	private void Update()
	{
		UpdateScoreText();
	}

	private void UpdateScoreText()
	{
		if (scoreText == null)
		{
			return;
		}

		int points = collectionEffect != null ? collectionEffect.points : 0;
		scoreText.text = "Points: " + points + " / " + totalPoints;
	}
}
