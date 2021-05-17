using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HorizontalObstacleMovement : MonoBehaviour
{
    [SerializeField] private HorizontalObstacleProperties horizontalObstacleProperties;

    private Rigidbody _rb;

    private void Awake() => _rb = GetComponent<Rigidbody>();
    private void FixedUpdate()
    {
        if (GameManager.GameStates.GamePlayRun == GameManager.Instance.CurrentState)
        {
            float x, y, z;

            x = transform.position.x;
            y = transform.position.y;
            z = Mathf.Sin(Time.time * horizontalObstacleProperties.frequence) * horizontalObstacleProperties.amplitude;

            _rb.transform.position = new Vector3(x, y, z);
        }
    }
}

