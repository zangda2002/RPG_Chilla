using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{
    public string transitionName;
	
	private void Start(){
		if(transitionName == SceneManagement.Instance.SceneTransitionName){
			PlayerController.Instance.transform.position = this.transform.position;
			CameraController.Instance.SetLayerCamerafollow();
			UIFade.Instance.FadeToClear();
		}
	}
}
