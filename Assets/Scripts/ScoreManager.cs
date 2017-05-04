using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
	public float timeBeforeDestruction = 1f;
	private int score = 0;
	

	public void IncScore(int amount = 1) {
		score += amount;
		scoreText.text = score.ToString();
	}

	public void Die() {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
		Invoke("ResetScene", timeBeforeDestruction);
	}

	private void ResetScene() {
		SceneManager.LoadScene(0);
	}
}
