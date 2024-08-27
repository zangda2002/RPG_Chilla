using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
	public Material whiteFlash;
	public float restoreDefaultMatTime = .2f;

	private Material defaultMat;
	private SpriteRenderer spriteRenderer;
	

	private void  Awake(){	
		spriteRenderer = GetComponent<SpriteRenderer>();
		defaultMat = spriteRenderer.material;
	}

	public float GetRestoredMatTime(){
		return restoreDefaultMatTime;
	}

	public IEnumerator FlashRoutine() {
		spriteRenderer.material = whiteFlash;
		yield return new WaitForSeconds(restoreDefaultMatTime);
		spriteRenderer.material = defaultMat;		
	} 
}
