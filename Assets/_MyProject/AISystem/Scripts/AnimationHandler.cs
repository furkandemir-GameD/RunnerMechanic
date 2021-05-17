using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void Run()
    {
        _animator.SetBool("RunCondiation", true);
        _animator.SetBool("FallCondiation", false);
    }
    public void Pause()
    {
        _animator.SetBool("RunCondiation", false);
        _animator.SetBool("FallCondiation", false);
        _animator.SetBool("IdleCondiation", true);
    }
    public void Collision()
    {
        _animator.SetBool("FallCondiation", true);
    }

    public void CollisionPause()
    {
        _animator.SetBool("FallCondiation", false);
    }
}
