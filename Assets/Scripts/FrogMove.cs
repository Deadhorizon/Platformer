using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : MonoBehaviour
{
	public float speed = 10.0f;
	public float timer = 5.0f;
	private float currentTime;
	private float direction = -1.0f;


	Animator animator;
	Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    
	{
		rg = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		currentTime = timer;
    }

    // Update is called once per frame
    void Update()
    {
		if (currentTime < 0)
		{
			currentTime = timer;
			direction = -direction;
		}
		currentTime -= Time.deltaTime;

		rg.velocity = new Vector2(speed * direction*Time.deltaTime, 0);
		animator.SetFloat("Speed", rg.velocity.x);
    }
	void OnCollisionEnter2D(Collision2D other)
	{
		PlayerController controller = other.gameObject.GetComponent<PlayerController>();
		if (controller != null)
		{
			controller.ChangeHealth(-1);
			controller.animator.SetTrigger("Hit");
		}
	}
}
