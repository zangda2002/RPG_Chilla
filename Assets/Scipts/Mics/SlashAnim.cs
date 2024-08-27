using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slasj : MonoBehaviour
{
	private ParticleSystem ps;

	private void Awake(){
		ps = GetComponent<ParticleSystem>();
	}

	private void Destroy(){
		if(ps && !ps.IsAlive()){
			DestroySelf();
		}
	}
	
	public void DestroySelf() {
		Destroy(gameObject);
	}
}
