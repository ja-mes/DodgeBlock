using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour {

	public Text highScore;

	void Start () {
		highScore.text = "HIGH SCORE: " + PlayerPrefs.GetInt("HighScore").ToString();
	}
}
