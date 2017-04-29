using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
	private int score = 0;

	public void IncScore() {
		score ++;

		scoreText.text = score.ToString();
	}

	public void Die() {
		SceneManager.LoadScene(0);
	}
}
