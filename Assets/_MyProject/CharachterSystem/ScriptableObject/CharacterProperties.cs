using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterProperties", menuName = "ScriptableObjects/CharacterProperties", order = 1)]
public class CharacterProperties : ScriptableObject
{
    [SerializeField] private float Speed;
    public float speed { get { return Speed; } private set { Speed = value; } }

    [SerializeField] private float AnimationDelayTime;
    public float animationDelayTime { get { return AnimationDelayTime; } private set { AnimationDelayTime = value; } }
}
