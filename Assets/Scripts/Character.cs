using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
	protected float speed;
	protected Vector2 direction;
	protected Rigidbody2D rb;
	protected int hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	protected void Move()
	{
		Vector2 velo = new Vector2(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
		rb.velocity = velo;
		//transform.Translate(direction * speed);
	}
}
