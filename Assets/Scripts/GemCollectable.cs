using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollectable : MonoBehaviour
{
	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController controller = other.gameObject.GetComponent<PlayerController>();
		if (controller != null)
		{
			controller.CurrentProgress = 1;
			Destroy(gameObject);
		}
	}
}
