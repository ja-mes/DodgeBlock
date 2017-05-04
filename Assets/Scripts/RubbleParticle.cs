using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubbleParticle : MonoBehaviour {

	public float movement = 10;
	Rigidbody2D rb;
	

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        Vector3 velocity = new Vector3(0.0f, 0.0f, Random.Range(-6.0f, -1.0f));
        rb.AddForce(velocity * movement);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
