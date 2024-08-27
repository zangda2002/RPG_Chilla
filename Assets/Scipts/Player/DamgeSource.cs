using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamgeSource : MonoBehaviour
{

	public int damageAmount = 1;

	private void OnTriggerEnter2D(Collider2D other){
		EnemiesHealth enemyHealth = other.gameObject.GetComponent<EnemiesHealth>();
		enemyHealth?.TakeDamage(damageAmount);
		
	}
}
