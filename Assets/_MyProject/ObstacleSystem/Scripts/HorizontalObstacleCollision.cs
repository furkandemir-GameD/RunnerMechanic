using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class HorizontalObstacleCollision : MonoBehaviour
{
    [SerializeField] private HorizontalObstacleProperties horizontalObstacleProperties;
    private GameObject tempCollision;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player") || collision.transform.CompareTag("AI"))
        {
            tempCollision = collision.gameObject;   
            collision.rigidbody.AddForce(collision.impulse * horizontalObstacleProperties.impactCollidingObject, ForceMode.Impulse);
            Vector3 vec3Buff = transform.eulerAngles;
            collision.transform.DOLookAt(transform.position, horizontalObstacleProperties.rotationDuration,AxisConstraint.Y);
            Run.After(horizontalObstacleProperties.regulationTime,  () => { tempCollision.transform.DORotate(new Vector3(0,-90,0), horizontalObstacleProperties.rotationDuration); }); 
        }
    }
}
