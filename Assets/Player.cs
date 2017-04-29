using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

	public Transform[] movePoints;

	private Rigidbody2D rb;
	private int currentMovePoint = 1;
    private float currentX;


	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");

        print(currentMovePoint + ", " +  x);

        if (x == currentX)
            return;

        if (x == -1)
        {
            if (currentMovePoint > 0) {
				currentMovePoint -= 1;
                rb.MovePosition(movePoints[currentMovePoint].position);
			}

        }
        else if (x == 1)
        {
			if (currentMovePoint < 2) {
				currentMovePoint += 1;
				rb.MovePosition(movePoints[currentMovePoint].position);
			}
        }


        currentX = x;
    }

}
