using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Lean.Common;
public class CharacterController : MonoBehaviour
{
    public bool hasRun = true;
    public bool hasCollision;

    [SerializeField] private LeanManualTranslate leanManualTranslate;
    [SerializeField] private CharacterProperties characterProperties;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Animator _animator;
 
    private void FixedUpdate()
    {
        if (GameManager.GameStates.GamePlayRun == GameManager.Instance.CurrentState)
        {
            _animator.SetBool("RunCondiation", true);
            CharachterMovement();
            SpeedLimiter();
        }
        else
        {
            AnimationsPause();
        }
    }
    private void CharachterMovement()
    {
        if (hasRun && hasCollision)
        {
            _rb.velocity = -Vector3.right * characterProperties.speed;
        }
        if (Input.GetMouseButton(0) && hasRun && hasCollision)
        {
            _rb.velocity = new Vector3(-characterProperties.speed, 0, leanManualTranslate.newDelta.z);
        }
    }
    private void SpeedLimiter()
    {
        if (_rb.velocity.magnitude > characterProperties.speed)
        {
            _rb.velocity = _rb.velocity.normalized * characterProperties.speed;
        }
    }
    private void AnimationsPause()
    {
        _animator.SetBool("RunCondiation", false);
        _animator.SetBool("FallCondiation", false);
        _animator.SetBool("IdleCondiation", true);
    }
}
