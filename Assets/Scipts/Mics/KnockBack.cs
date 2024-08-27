using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
	public bool GettingKnockedBack { get; private set; }

	public float knockBackTime = .2f;
	
	private Rigidbody2D rb;

	private void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	public void GetKnockBack(Transform damageSource, float knockBackThrust){
		GettingKnockedBack = true;
		Vector2 diff = (transform.position - damageSource.position).normalized * knockBackThrust * rb.mass;
		rb.AddForce(diff, ForceMode2D.Impulse);
		StartCoroutine(KnockRoutine());
	}
	
	private IEnumerator KnockRoutine(){
		yield return new WaitForSeconds(knockBackTime);
		rb.velocity = Vector2.zero;
		GettingKnockedBack = false;
	}
}
