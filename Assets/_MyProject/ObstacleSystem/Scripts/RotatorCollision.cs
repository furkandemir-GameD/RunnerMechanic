using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
public class RotatorCollision : MonoBehaviour
{
    [SerializeField] private Transform mainRotator;
    [SerializeField] private RotatorObstacleProperties rotatorObstacleProperties;
    private GameObject go;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("AI"))
        {
            go = collision.gameObject;

            collision.rigidbody.AddForce(collision.impulse * rotatorObstacleProperties.impactCollidingObject, ForceMode.Impulse);

            Vector3 obstacleMidPoint = Vector3.zero;
            for (int i = 0; i < collision.contactCount; i++)
            {
                obstacleMidPoint = collision.GetContact(i).point + obstacleMidPoint;
            }
            obstacleMidPoint /= collision.contactCount;
            if (Convert.ToInt32(obstacleMidPoint.z)>Convert.ToInt32(mainRotator.position.z))
            {
                mainRotator.DOBlendablePunchRotation(new Vector3(-collision.impulse.x, 0, collision.impulse.x) * rotatorObstacleProperties.punchScale,
                    rotatorObstacleProperties.punchDuration, rotatorObstacleProperties.vibrato, rotatorObstacleProperties.elasticy).SetEase(Ease.InOutElastic).Elapsed();
            }
            else if (Convert.ToInt32(obstacleMidPoint.z-0.5f)==Convert.ToInt32(transform.position.z))
            {
                mainRotator.DOBlendablePunchRotation(new Vector3(0, 0, collision.impulse.x) * rotatorObstacleProperties.punchScale,
                   rotatorObstacleProperties.punchDuration, rotatorObstacleProperties.vibrato, rotatorObstacleProperties.elasticy).SetEase(Ease.InOutElastic).Elapsed();
            }
            else
            {
                mainRotator.DOBlendablePunchRotation(new Vector3(collision.impulse.x, 0, collision.impulse.x) * rotatorObstacleProperties.punchScale,
                   rotatorObstacleProperties.punchDuration, rotatorObstacleProperties.vibrato, rotatorObstacleProperties.elasticy).SetEase(Ease.InOutElastic).Elapsed();
            }
            Vector3 vec3Buff = transform.eulerAngles;
            collision.transform.DOLookAt(transform.position, rotatorObstacleProperties.rotationDuration, AxisConstraint.Y);
            Run.After(rotatorObstacleProperties.regulationTime, () => 
            {
                go.transform.DORotate(new Vector3(0, rotatorObstacleProperties.charachterDefaultRotation, 0), rotatorObstacleProperties.rotationDuration);
            });

        }

    }
}
