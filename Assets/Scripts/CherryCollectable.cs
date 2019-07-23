using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollectable : MonoBehaviour
{
	PlayerController controller;

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log(other);
		controller = other.gameObject.GetComponent<PlayerController>();

		if (controller != null)
		{
			if (controller.Health < controller.maxHealth)
			{
				controller.ChangeHealth(1);
				Destroy(gameObject);
			}
		}

	}
}
