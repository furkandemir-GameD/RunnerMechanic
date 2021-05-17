using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetCalculator : MonoBehaviour
{
    public float radius;

    [SerializeField] private Rigidbody _rb;
    [SerializeField] private AIHandler aIHandler;
    [SerializeField] private AnimationHandler animationHandler;
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private Vector3 direction;
    [SerializeField] private AIProperties aIProperties;

    private float maxDistance;
    public void CastScan()
    {
        maxDistance = aIProperties.speed / aIProperties.sensivity;

        Ray ray = new Ray();
        ray.direction = direction;
        ray.origin = transform.position;
        if (Physics.SphereCast(ray, radius, maxDistance, hitMask))
        {
            int rand = Random.RandomRange(0, 100);
            aIHandler.WallOffset(rand);
            float delay = maxDistance / aIProperties.speed;
            aIHandler.hasRun = false;
            Run.After(delay, () => aIHandler.hasRun = true);
        }
        else
        {
            _rb.velocity = new Vector3(-aIProperties.speed, 0, 0);
        }
        animationHandler.Run();
    }
}
