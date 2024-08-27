using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AreaExit : MonoBehaviour
{
	public string sceneToLoad;
	public string sceneTransitionName;

	private float waitLoadTime = 1f;

	private void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.GetComponent<PlayerController>()){
			SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            UIFade.Instance.FadeToBlack();
			StartCoroutine(LoadSceneRoutine());
        }
	}

	private IEnumerator LoadSceneRoutine()
	{
		while(waitLoadTime >= 0)
		{
			waitLoadTime -= Time.deltaTime;
			yield return null;
		}
		SceneManager.LoadScene(sceneToLoad);
	}
}
