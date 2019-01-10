using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	// Use this for initialization
	void Start () {
		speed = 300f;
		rb = GetComponent<Rigidbody2D>();
		hp = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DisablePlayerMovement()
	{
		speed = 0f;
	}

	public void EnablePlayerMovement()
	{
		speed = 300f;
	}

	private void FixedUpdate()
	{
		direction.x = 0;
		direction.y = 0;
		if (Input.GetKey(KeyCode.A))
		{
			direction.x = -1;
		}
		if (Input.GetKey(KeyCode.W))
		{
			direction.y = 1;
		}
		if (Input.GetKey(KeyCode.D))
		{
			direction.x = 1;
		}
		if (Input.GetKey(KeyCode.S))
		{
			direction.y = -1;
		}
		Move();
	}

}

