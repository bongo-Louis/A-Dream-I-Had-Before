using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI scoreText;
	[SerializeField] private CollectionEffect collectionEffect;

	private void Start()
	{
		if (collectionEffect == null)
		{
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			if (player != null)
			{
				collectionEffect = player.GetComponent<CollectionEffect>();
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
		scoreText.text = "Points: " + points;
	}
}
