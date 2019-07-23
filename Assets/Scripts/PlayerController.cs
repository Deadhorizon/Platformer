using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	//public tags
	public float speed=3.0f;
	public float force = 10000.0f;
	public int progress = 5;
	public int maxHealth = 3;

	// private tags
	private bool isJumping = false;
	private float move;
	private float lastInput;
	private int currentHealth=2;
	private int currentProgress = 0;



	//properties 

	public int CurrentProgress
	{
		get
		{
			return currentProgress;
		}
		set
		{
			currentProgress =currentProgress + value;
		}
 	}

	 public int Health
	{
		get
		{
			return currentHealth;
		}
	}


	//Components
	Vector2 direction;
	Rigidbody2D rb2d;
	public Animator animator;

    void Start()
    {
		rb2d = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
		float input_X=Input.GetAxis("Horizontal");
		if (!Mathf.Approximately(input_X, 0.0f))
		{
			lastInput = input_X;
		}
		animator.SetFloat("Look", lastInput);
		move = speed * input_X;
		animator.SetFloat("Speed", move);
		rb2d.velocity = new Vector2(move, rb2d.velocity.y);
		if (Input.GetKey("space"))
		{
			if (!isJumping)
			{
				rb2d.AddForce(new Vector2(transform.position.x,force));
				isJumping = true;
				animator.SetBool("Jump", isJumping);
			}
		}
    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			isJumping = false;
			animator.SetBool("Jump", isJumping);
			rb2d.velocity = Vector2.zero;
		}
	}
	public void ChangeHealth(int hp)
	{
			currentHealth += hp;
	}
}
