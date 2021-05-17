using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HalfDonutMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody stickBody;
    [SerializeField] private HalfDonutProperties halfDonutProperties;

    private float firstFramePositionXZAxis;

    private void Awake() => firstFramePositionXZAxis = stickBody.transform.position.z;

    void FixedUpdate()
    {
        if (GameManager.GameStates.GamePlayRun == GameManager.Instance.CurrentState)
        {
            float x, y, z;
            z = Mathf.Cos(Time.time * halfDonutProperties.frequence) * halfDonutProperties.amplitude + firstFramePositionXZAxis;
            x = stickBody.transform.position.x;
            y = stickBody.transform.position.y;
            stickBody.transform.position = new Vector3(x, y, z);
        }
    }
}
