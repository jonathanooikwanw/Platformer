using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //need to be able to manipulate text

public class ScoreManager : MonoBehaviour
{
	public Text scoreText;
	public Text highScoreText;

	public float scoreCounter;
	public float highScoreCounter;

	public float pointsPerSecond;
	private ScoreManager scoreManager;

	public bool scoreIncrease;

	// Start is called before the first frame update
	void Start()
    {
        if(PlayerPrefs.HasKey("HighScore"))
		{
			highScoreCounter = PlayerPrefs.GetFloat("Highscore");
		}
    }

    // Update is called once per frame

    void Update()
    {
		if (scoreIncrease)
		{
			scoreCounter += pointsPerSecond * Time.deltaTime; //deltatime is the time taken from last update to the next
		}

		if(scoreCounter > highScoreCounter)
		{
			highScoreCounter = scoreCounter;
			//playerprefs = save system
			//save value highscore and current highscore
			//moment game start, check value and apply to highscore
			PlayerPrefs.SetFloat("HighScore", highScoreCounter);
		}

		//accessing the text
		scoreText.text = "Score : " + Mathf.Round(scoreCounter);
		highScoreText.text = "High Score : " + Mathf.Round(highScoreCounter);
    }
}
