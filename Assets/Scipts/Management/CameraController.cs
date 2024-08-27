using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : SingleTon<CameraController>
{
    private CinemachineVirtualCamera cineVirtualCam;

    public void SetLayerCamerafollow()
    {
        cineVirtualCam = FindObjectOfType<CinemachineVirtualCamera>();
        cineVirtualCam.Follow = PlayerController.Instance.transform;
    }
}
