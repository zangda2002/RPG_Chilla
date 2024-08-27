using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
	public GameObject destroyVFX;
	private void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<DamgeSource>()){
			Instantiate(destroyVFX, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}		
	}

}
