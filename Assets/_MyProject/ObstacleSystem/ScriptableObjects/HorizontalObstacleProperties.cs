using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HorizontalObstacleProperties", menuName = "ScriptableObjects/HorizontalObstacleProperties", order = 1)]
public class HorizontalObstacleProperties : ScriptableObject
{
    [SerializeField] private float Frequnce;
    public float  frequence { get { return Frequnce; } private set { Frequnce = value; } }

    [SerializeField] private float Amplitude;
    public float amplitude { get { return Amplitude; } private set { Amplitude = value; } }

    [SerializeField] private float ImpactCollidingObject;
    public float impactCollidingObject { get { return ImpactCollidingObject; } private set { ImpactCollidingObject = value; } }

    [SerializeField] private float RegulationTime;
    public float regulationTime { get { return RegulationTime; } private set { RegulationTime = value; } }

    [SerializeField] private float RotationDuration;
    public float rotationDuration { get { return RotationDuration; } private set { RotationDuration = value; } }
}
