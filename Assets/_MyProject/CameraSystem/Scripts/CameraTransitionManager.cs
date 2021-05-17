using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

public class CameraTransitionManager : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera tpsCamera;
    [SerializeField] private CinemachineVirtualCamera fpsCamera;

    [SerializeField] private CinemachineCollisionImpulseSource MyInpulse;

    public void CameraTransistionFPS()
    {
        tpsCamera.enabled = false;
        fpsCamera.enabled = true;
    }
    public void CameraShake()
    {
        MyInpulse.GenerateImpulse();
    }


}
