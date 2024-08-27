using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour
{	
	public int startingHealth = 3;
	public GameObject deathVFXprefab;
	public float knockBackThrust = 7f;	

	private int currentHealth;
	private KnockBack kb;
	private Flash flash;

	private void Awake()
	{
		flash = GetComponent<Flash>();
		kb = GetComponent<KnockBack>();
	}


	private void Start(){
		currentHealth = startingHealth;
	}

	public void TakeDamage(int damage) {
		currentHealth -= damage;
		kb.GetKnockBack(PlayerController.Instance.transform, knockBackThrust);	
		StartCoroutine(flash.FlashRoutine());
		StartCoroutine(CheckDetectDeathRoutine());
	}

	private IEnumerator CheckDetectDeathRoutine(){
		yield return new WaitForSeconds(flash.GetRestoredMatTime());
		DetectDeath();
	}

	public void DetectDeath(){
		if(currentHealth <= 0) {
			Instantiate(deathVFXprefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}
