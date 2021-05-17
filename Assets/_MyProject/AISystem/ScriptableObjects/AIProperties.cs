using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AIProperties", menuName = "ScriptableObjects/AIProperties", order = 1)]
public class AIProperties : ScriptableObject
{
    [SerializeField] private float Speed;
    public float speed { get { return Speed; } private set { Speed = value; } }

    [SerializeField] private float Sensivity;
    public float sensivity { get { return Sensivity; } private set { Sensivity = value; } }

    private int Intelligence=60;
    public int intelligence { get { return Intelligence; } private set { Intelligence = value; } }

    [SerializeField] private float EscapeSpeed;
    public float escapeSpeed { get { return EscapeSpeed; } private set { EscapeSpeed = value; } }
}
