using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonutCollision : MonoBehaviour
{
    [SerializeField] private HalfDonutProperties halfDonutProperties;
    [SerializeField] private VFXHandler vFXHandler;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            vFXHandler.StartPointTransform(collision);
        }
        else if (collision.transform.CompareTag("AI"))
        {
            vFXHandler.StartPointTransform(collision);
        }
    }
}
