using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour {
	public ParticleSystem ps;
	public float timeScale = 0.5f;
	public float resetTime = 3;

		
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Player") {
			Time.timeScale = timeScale;

			Invoke("resetTimeScale", resetTime * (1 - timeScale));
		}
	}

	void resetTimeScale() {
		Time.timeScale = 1;
	}

}
