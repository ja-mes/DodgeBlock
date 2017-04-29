using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : MonoBehaviour {

	public int scoreAmountToAdd = 10;
	private ScoreManager scoreManager;

	void Start() {
		scoreManager = FindObjectOfType<ScoreManager>();
	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			scoreManager.IncScore(10);
		}
	}
}
