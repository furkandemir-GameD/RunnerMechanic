using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RotatorObstacleProperties", menuName = "ScriptableObjects/RotatorObstacleProperties", order = 1)]
public class RotatorObstacleProperties : ScriptableObject
{
    [SerializeField] private float ImpactCollidingObject;
    public float impactCollidingObject { get { return ImpactCollidingObject; } private set { ImpactCollidingObject = value; } }

    [SerializeField] private float CharachterDefaultRotation;
    public float charachterDefaultRotation { get { return CharachterDefaultRotation; } private set { CharachterDefaultRotation = value; } }

    [SerializeField] private float RegulationTime;
    public float regulationTime { get { return RegulationTime; } private set { RegulationTime = value; } }

    [SerializeField] private float RotationDuration;
    public float rotationDuration { get { return RotationDuration; } private set { RotationDuration = value; } }

    [Header("Elastic Object")]
    [SerializeField] private float PunchScale;
    public float punchScale { get { return PunchScale; } private set { PunchScale = value; } }

    [SerializeField] private float PunchDuration;
    public float punchDuration { get { return PunchDuration; } private set { PunchDuration = value; } }

    [SerializeField] private int Vibrato;
    public int vibrato { get { return Vibrato; } private set { Vibrato = value; } }

    [SerializeField] private float Elasticy;
    public float elasticy { get { return Elasticy; } private set { Elasticy = value; } }
}
