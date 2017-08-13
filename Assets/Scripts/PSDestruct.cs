using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSDestruct : MonoBehaviour
{
	public float destructionTime = 6;

	void Update()
	{
		destructionTime -= Time.deltaTime;

		if (destructionTime <= 0)
		{
			Destroy(gameObject);
		}
	}
}
