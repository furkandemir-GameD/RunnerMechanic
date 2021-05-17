using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbleSeeRadius : MonoBehaviour
{
    [SerializeField] private OffsetCalculator offsetCalculator;
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, offsetCalculator.radius);
    }
#endif
}
