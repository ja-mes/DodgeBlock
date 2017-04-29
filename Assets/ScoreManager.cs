using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
	private int score = 0;

	public void IncScore() {
		print("inc score");
		score ++;

		scoreText.text = score.ToString();
	}

	public void Die() {

	}
}
