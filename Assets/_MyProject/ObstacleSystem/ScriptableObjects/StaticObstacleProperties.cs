using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "StaticObstacleProperties", menuName = "ScriptableObjects/StaticObstacleProperties", order = 1)]
public class StaticObstacleProperties : ScriptableObject
{
    [SerializeField] private float ImpactCollidingObject;
    public float impactCollidingObject { get { return ImpactCollidingObject; } private set { ImpactCollidingObject = value; } }

    [SerializeField] private float RegulationTime;
    public float regulationTime { get { return RegulationTime; } private set { RegulationTime = value; } }

    [SerializeField] private float RotationDuration;
    public float rotationDuration { get { return RotationDuration; } private set { RotationDuration = value; } }
}
