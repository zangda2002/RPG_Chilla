using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesPath : MonoBehaviour
{
	private float moveSpeed = 2f;
	
	private Rigidbody2D rb;
	private Vector2 moveDir;

	private KnockBack kb;

	private void Awake()
	{
		kb = GetComponent<KnockBack>();
		rb = GetComponent<Rigidbody2D>();		
	}

	private void FixedUpdate()
	{
		if(kb.GettingKnockedBack) {return; }
		rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));	
	}

	public void MoveTo(Vector2 targetPosition)
	{
		moveDir = targetPosition;
	}
}
