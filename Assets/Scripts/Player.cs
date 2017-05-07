using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ParticleSystem part;
    public Transform movePoint1;
    public Transform movePoint2;
    public float lerpSpeed = 20f;
    private float adjustedLerpSpeed;

	private Rigidbody2D rb;
    private Transform des;
    private SpriteRenderer sRenderer;


	void Start() {
        sRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
        adjustedLerpSpeed = lerpSpeed;
        des = movePoint1;
	}

    void Update()
    {
        if (Globals.GM.playerHasShield)
        {
            sRenderer.color = new Color32(255, 177, 60, 255);
        } else {
            sRenderer.color = Color.white;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (des == movePoint1)
                des = movePoint2;
            else
                des = movePoint1;
        }


        rb.MovePosition(Vector3.Lerp(transform.position, des.position, lerpSpeed * (1 / Time.timeScale) * Time.deltaTime));
    }

    public void InvokeExplosion()
    {
        ParticleSystem newPart = Instantiate(part, transform.position, Quaternion.identity);
        newPart.Play();
    }
}
