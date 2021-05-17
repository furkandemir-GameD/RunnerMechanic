using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{
    [SerializeField] private CharacterProperties characterProperties;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Animator _animator;
    [SerializeField] private ParticleSystem staggerPS;

    private CameraTransitionManager cameraTransitionManager;
    private void Awake() => cameraTransitionManager = GameObject.FindWithTag("CameraManager").GetComponent<CameraTransitionManager>();
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            cameraTransitionManager.CameraShake();
            staggerPS.Stop();

            _animator.SetBool("FallCondiation", true);

            characterController.hasRun = false;
            Run.After(characterProperties.animationDelayTime, () => { characterController.hasRun = true; });
        }
        if (collision.transform.CompareTag("Ground"))
        {
            characterController.hasCollision = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            staggerPS.Play();
            _animator.SetBool("FallCondiation", false);

        }
        if (collision.transform.CompareTag("Ground"))
        {
            characterController.hasCollision = false;
        }
    }
}
