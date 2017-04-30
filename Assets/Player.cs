using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem part;
    public Transform movePoint1;
    public Transform movePoint2;
    public float lerpSpeed = 20f;

	private Rigidbody2D rb;
    private Transform des;


	void Start() {
		rb = GetComponent<Rigidbody2D>();
        des = movePoint1;
	}

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            if (des == movePoint1)
                des = movePoint2;
            else 
                des = movePoint1;
        }

        rb.MovePosition(Vector3.Lerp(transform.position, des.position, lerpSpeed * Time.deltaTime));
    }

    public void InvokeExplosion() {
        ParticleSystem newPart = Instantiate(part, transform.position, Quaternion.identity);
        newPart.Play();
    }
}
