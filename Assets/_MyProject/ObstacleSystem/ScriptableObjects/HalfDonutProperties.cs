using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HalfDonutProperties", menuName = "ScriptableObjects/HalfDonutProperties", order = 1)]
public class HalfDonutProperties : ScriptableObject
{
    [SerializeField] private float Amplitude;
    public float amplitude { get { return Amplitude; } private set { Amplitude = value; } }

    [SerializeField] private float Frequnce;
    public float frequence { get { return Frequnce; } private set { Frequnce = value; } }

    [SerializeField] private float MagnetForce;
    public float magnetForce { get { return MagnetForce; } private set { MagnetForce = value; } }

}
