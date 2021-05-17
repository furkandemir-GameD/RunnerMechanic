using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICollision : MonoBehaviour
{
    [SerializeField] private AIHandler aIHandler;
    [SerializeField] private ParticleSystem staggerPS;
    [SerializeField] private AnimationHandler animationHandler;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            staggerPS.Stop();

            animationHandler.Collision();

            aIHandler.collisionAfterHasRun = false;
            Run.After(1.5f, () => { aIHandler.collisionAfterHasRun = true; });
        }
        if (collision.transform.CompareTag("Ground"))
        {
            aIHandler.collisionGround = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            staggerPS.Play();
            animationHandler.CollisionPause();

        }
        if (collision.transform.CompareTag("Ground"))
        {
            aIHandler.collisionGround = false;
        }
    }
}
