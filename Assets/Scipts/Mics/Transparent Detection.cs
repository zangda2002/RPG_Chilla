using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class TransparentDetection : MonoBehaviour
{
	[Range(0, 1)]
	public float transpeAmount = 0.8f;
	public float fadeTime = .4f;

	private SpriteRenderer SprRender;
	private Tilemap tlm;

	private void Awake() {
		SprRender = GetComponent<SpriteRenderer>();
		tlm = GetComponent<Tilemap>();
	}

	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.GetComponent<PlayerController>()){
			if(SprRender){
				StartCoroutine(FadeRoutine(SprRender, fadeTime, SprRender.color.a, transpeAmount));
			}
			else if(tlm){
				StartCoroutine(FadeRoutine(tlm, fadeTime, tlm.color.a, transpeAmount));

			}
		}
	}

	private void OnTriggerExit2D(Collider2D other){
		if(other.gameObject.GetComponent<PlayerController>()){
			if(SprRender){
				StartCoroutine(FadeRoutine(SprRender, fadeTime, SprRender.color.a, 1f));
			}
			else if(tlm){
				StartCoroutine(FadeRoutine(tlm, fadeTime, tlm.color.a, 1f));

			}
		}

	}

	private IEnumerator FadeRoutine(SpriteRenderer SprRender, float fadeTime, float startValue, float targetTransparency){
		float elapsedTime = 0;
		while(elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime/fadeTime);
			SprRender.color = new Color(SprRender.color.r, SprRender.color.g, SprRender.color.b, newAlpha);
			yield return null;
		}	
	}

	
	private IEnumerator FadeRoutine(Tilemap tlm, float fadeTime, float startValue, float targetTransparency){
		float elapsedTime = 0;
		while(elapsedTime < fadeTime)
		{
			elapsedTime += Time.deltaTime;
			float newAlpha = Mathf.Lerp(startValue, targetTransparency, elapsedTime/fadeTime);
			tlm.color = new Color(tlm.color.r, tlm.color.g, tlm.color.b, newAlpha);
			yield return null;
		}	
	}


}
