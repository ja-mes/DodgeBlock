using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public Text scoreText;
	public float timeBeforeDestruction = 1f;
	private int score = 0;
	private bool isDead = false;

	public void IncScore(int amount = 1) {
        if (!isDead) {
            score += amount;
            scoreText.text = score.ToString();
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Invoke("ResetScene", timeBeforeDestruction);
        
        GameManager gl = GameObject.FindObjectOfType<GameManager>();

        if (gl != null) 
            gl.score = score;

		if(PlayerPrefs.GetInt("HighScore") < score) {
			PlayerPrefs.SetInt("HighScore", score);
		}
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(2);
    }
}
