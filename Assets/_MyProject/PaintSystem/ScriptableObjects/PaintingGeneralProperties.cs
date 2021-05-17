using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PaintingGeneralProperties", menuName = "ScriptableObjects/PaintingGeneralProperties", order = 1)]
public class PaintingGeneralProperties : ScriptableObject
{
    [Header("Before Painting")]
    [SerializeField] private float HandMoveDuration;
    public float handMoveDuration { get { return HandMoveDuration; } private set { HandMoveDuration = value; } }

    [SerializeField] private float HandRotateDuration;
    public float handRotateDuration { get { return HandRotateDuration; } private set { HandRotateDuration = value; } }

    [Header("Final Line")]
    [SerializeField] private float AnimationSpeed;
    public float animationSpeed { get { return AnimationSpeed; } private set { AnimationSpeed = value; } }

    [SerializeField] private float CharachterHandMovementDuration;
    public float charachterHandMovementDuration { get { return CharachterHandMovementDuration; } set { CharachterHandMovementDuration = value; } }

    [SerializeField] private float CameraTransitionDuration;
    public float cameraTransitionDuration { get { return CameraTransitionDuration; } set { CameraTransitionDuration = value; } }

    [SerializeField] private float PercentPaintThreshold;
    public float percentPaintThreshold { get { return PercentPaintThreshold/100; } set { PercentPaintThreshold = value; } }
}
