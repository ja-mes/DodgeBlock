using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
	public Text score; 

	void Start() {
        Debug.Log(FindObjectOfType<GameManager>());
		score.text = "SCORE: " + FindObjectOfType<GameManager>().score.ToString();
	}
}
