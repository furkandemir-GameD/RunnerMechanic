using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticObstacleCollision : MonoBehaviour
{
    [SerializeField] private StaticObstacleProperties staticObstacleProperties;
    private GameObject tempCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("AI"))
        {
            tempCollision = collision.gameObject;
            
            Vector3 contactPosition=Vector3.zero;
            for (int i = 0; i < collision.contactCount; i++)
            {
                contactPosition += collision.contacts[i].point;
            }
            contactPosition = contactPosition / collision.contactCount;
            Vector3 vec3Buff = transform.eulerAngles;
            
            collision.transform.DOLookAt(contactPosition, staticObstacleProperties.rotationDuration, AxisConstraint.Y);
            collision.rigidbody.AddForce(collision.impulse * staticObstacleProperties.impactCollidingObject, ForceMode.Impulse);
            Run.After(staticObstacleProperties.regulationTime, () => { tempCollision.transform.DORotate(new Vector3(0, -90, 0), staticObstacleProperties.rotationDuration); });
        }
    }
}
